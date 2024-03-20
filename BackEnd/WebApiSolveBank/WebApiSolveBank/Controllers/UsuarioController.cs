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
        public UsuarioController(IUsuarioRepository usuarioRepository, IContaBancariaRepository contaBancariaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _contaBancariaRepository = contaBancariaRepository;
        }


        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] RequestCriarUsuarioDTO requestCriarUsuarioDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
                Limite= 150,
                UsuarioID= usuarioResult,
                Informacoes= "Conta nova, recem criada"
            };
            await _contaBancariaRepository.CriarConta(contaBancaria);
            return Ok("Usuário cadastrado com sucesso");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] RequestUsuarioLogin requestUsuarioLogin)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var loginResponse =  await _usuarioRepository.Logar(requestUsuarioLogin.Cpf_Cnpj, requestUsuarioLogin.Senha);
            if(loginResponse == null) return BadRequest(loginResponse);            
            return Ok("Usuário encontrado Token Enviado");
        }

        [HttpGet("Autenticar")]

        public async Task<IActionResult> AutenticarUsuario([FromBody] string token2Fatores)
        {



            return Ok();
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] RequestUsuarioLogin requestUsuarioLogin)
        {
            return Ok();
        }
        [HttpPut("desativar/{usuarioID}")]
        public async Task<IActionResult> DesativarUsuario([FromBody] string usuarioID)
        {
            return Ok();
        }


    }
}
