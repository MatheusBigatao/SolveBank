using Microsoft.AspNetCore.Mvc;
using SolveBank.Entities.DTOs.Usuario;
using SolveBank.Entities.DTOs.UsuarioDTOs;
using SolveBank.Entities.Enums;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using SolveBank.Infrastructure.Repositories.Services;

namespace WebApiSolveBank.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IAutenticacao2FatoresRepository _autenticacao2Repository;
        private readonly IWebTokenRepository _webTokenRepository;
        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            IContaBancariaRepository contaBancariaRepository,
            IAutenticacao2FatoresRepository autenticacao2FatoresRepository,
            IWebTokenRepository webTokenRepository
            )
        {
            _usuarioRepository = usuarioRepository;
            _contaBancariaRepository = contaBancariaRepository;
            _autenticacao2Repository = autenticacao2FatoresRepository;
            _webTokenRepository = webTokenRepository;
        }


        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] RequestCriarUsuarioDTO requestCriarUsuarioDTO)
        {
            if (!ModelState.IsValid || requestCriarUsuarioDTO.Senha != requestCriarUsuarioDTO.ConfirmarSenha)
                return BadRequest(ModelState.ToString() + "Verifique a senha e confirmação de senha");

            var usuarioCadastro = new Usuario()
            {
                NomeCompleto = $"{requestCriarUsuarioDTO.Nome} {requestCriarUsuarioDTO.Sobrenome}",
                Email = requestCriarUsuarioDTO.Email,
                PhoneNumber = requestCriarUsuarioDTO.Telefone,
                EnumTipoUsuario = EnumTipoUsuario.Cliente,
                Removido = false,
                DataCadastro = DateTime.Now,
                CPF_CNPJ = requestCriarUsuarioDTO.CPF_CNPJ,
                UserName = requestCriarUsuarioDTO.CPF_CNPJ
            };
            var usuarioResult = await _usuarioRepository.Cadastrar(usuarioCadastro, requestCriarUsuarioDTO.Senha);
                      
            
            var contaBancaria = new ContaBancaria()
            {
                Agencia = "0001",
                Saldo = 0,
                Limite = 150,
                UsuarioID = usuarioResult,
                Informacoes = "Conta nova, recem criada"
            };
            await _contaBancariaRepository.CriarConta(contaBancaria);
            return Ok("Usuário cadastrado com sucesso");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] RequestUsuarioLogin requestUsuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var loginResponse = await _usuarioRepository.Logar(requestUsuarioLogin.Cpf_Cnpj, requestUsuarioLogin.Senha);
            if (loginResponse == null) return BadRequest("Usuário não encontrado");
            return Ok("Usuário encontrado Token Enviado");
        }

        [HttpGet("Autenticar/{token2Fatores}")]
        public async Task<IActionResult> AutenticarUsuario(string token2Fatores)
        {
            var usuarioAutenticado = await _autenticacao2Repository.AutenticarUsuario(token2Fatores);
            if (usuarioAutenticado == null) return BadRequest("Token já utilizado, ou usuário não localizado");
            usuarioAutenticado.WebToken = await _webTokenRepository.CadastrarToken(usuarioAutenticado.Id);
            return Ok(usuarioAutenticado);
        }

        //TODO - IMPLEMENTAR METODOS PARA ATUALIZAR E DESATIVAR USUARIO
        //[HttpPut("atualizar")]
        //public async Task<IActionResult> AtualizarUsuario([FromBody] RequestUsuarioLogin requestUsuarioLogin)
        //{
        //    return Ok();
        //}
        //[HttpPut("desativar/{usuarioID}")]
        //public async Task<IActionResult> DesativarUsuario([FromBody] string usuarioID)
        //{
        //    return Ok();
        //}
    }
}
