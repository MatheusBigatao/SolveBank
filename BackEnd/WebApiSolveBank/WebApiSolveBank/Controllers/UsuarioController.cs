using Microsoft.AspNetCore.Mvc;
using SolveBank.Entities.DTOs.Usuario;
using SolveBank.Entities.DTOs.UsuarioDTOs;

namespace WebApiSolveBank.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] RequestCriarUsuarioDTO requestCriarUsuarioDTO)
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario([FromBody] RequestUsuarioLogin requestUsuarioLogin)
        {
            return Ok();
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
