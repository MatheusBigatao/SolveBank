using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.DTOs.ContaBancariaDTOs;
using SolveBank.Entities.DTOs.UsuarioDTOs;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Configuration;
using SolveBank.Infrastructure.ExternalServices.Contracts;
using SolveBank.Infrastructure.Repositories.Contracts;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class Autenticacao2FatoresService : IAutenticacao2FatoresRepository
    {
        private readonly SolveBankDbConfig _solveBankDbConfig;
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public Autenticacao2FatoresService(
            SolveBankDbConfig solveBankDbConfig,
            IMapper mapper,
            IEmailRepository email

            )
        {
            _solveBankDbConfig = solveBankDbConfig;
            _mapper = mapper;
            _emailRepository = email;
        }

        public async Task<ResponseExibirUsuarioDTO?> AutenticarUsuario(string autenticacaoToken)
        {
            var token2Fatores = await _solveBankDbConfig.Autenticacao2Fatores.FirstOrDefaultAsync(a => a.Token == autenticacaoToken);
            if (token2Fatores != null && token2Fatores.Utilizado != true)
            {
                var usuarioLogin = await _solveBankDbConfig.Usuarios.FindAsync(token2Fatores.UsuarioID);
                var usuarioRetorno = new ResponseExibirUsuarioDTO();
                _mapper.Map(usuarioLogin, usuarioRetorno);
                var contasBancarias = await _solveBankDbConfig.ContasBancarias.Where(c => c.UsuarioID == usuarioLogin.Id).ToListAsync();
                var contaBancariaDTO = new ResponseContaBancariaDTO();
                var listContaBancaria = new List<ResponseContaBancariaDTO>();
                foreach (var contaBancaria in contasBancarias)
                {
                    _mapper.Map(contaBancaria, contaBancariaDTO);
                    listContaBancaria.Add(contaBancariaDTO);
                }
                usuarioRetorno.ContaBancarias = listContaBancaria;
                token2Fatores.Utilizado = true;
                _solveBankDbConfig.Autenticacao2Fatores.Update(token2Fatores);
                await _solveBankDbConfig.SaveChangesAsync();
                return usuarioRetorno;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> CriarAutenticacao(Autenticacao2Fatores autenticacao2Fatores)
        {
            var usuario = await _solveBankDbConfig.Usuarios.FindAsync(autenticacao2Fatores.UsuarioID);
            if (usuario == null) return false;
            _solveBankDbConfig.Autenticacao2Fatores.Add(autenticacao2Fatores);
            await _solveBankDbConfig.SaveChangesAsync();
            await _emailRepository.SendToEmail(autenticacao2Fatores.CreateEmailBody(), usuario.Email);
            return true;
        }
    }
}
