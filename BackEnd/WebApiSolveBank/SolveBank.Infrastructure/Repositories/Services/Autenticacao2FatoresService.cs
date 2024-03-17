using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IWebTokenRepository _webTokenRepository;
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;

        public Autenticacao2FatoresService(
            SolveBankDbConfig solveBankDbConfig,
            IUsuarioRepository usuarioRepository,
            IWebTokenRepository webTokenRepository,
            IEmailRepository emailRepository,
            IMapper mapper
            )
        {
            _solveBankDbConfig = solveBankDbConfig;
            _usuarioRepository = usuarioRepository;
            _webTokenRepository = webTokenRepository;
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public async Task<ResponseExibirUsuarioDTO?> AutenticarUsuario(string autenticacaoToken)
        {
            var token2Fatores = await _solveBankDbConfig.Autenticacao2Fatores.FirstOrDefaultAsync(a => a.Token == autenticacaoToken);
            if (token2Fatores != null && token2Fatores.Utilizado != true)
            {
                var usuarioLogin = await _usuarioRepository.BuscarUsuario(token2Fatores.UsuarioID);
                var usuarioRetorno = new ResponseExibirUsuarioDTO();
                _mapper.Map(usuarioLogin, usuarioRetorno);
                usuarioRetorno.WebToken = await _webTokenRepository.CadastrarToken(usuarioLogin.Id);
                return usuarioRetorno;
            }
            else
            {
                return null;
            }          
        }   
        public async Task<bool> CriarAutenticacao(Autenticacao2Fatores autenticacao2Fatores)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(autenticacao2Fatores.UsuarioID);
            if(usuario == null) return false;
            _solveBankDbConfig.Autenticacao2Fatores.Add(autenticacao2Fatores);
            await _solveBankDbConfig.SaveChangesAsync();            
            await _emailRepository.SendToEmail(autenticacao2Fatores.CreateEmailBody(), usuario.Email);
            return true;
        }
    }
}
