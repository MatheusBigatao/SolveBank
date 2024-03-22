using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveBank.Infrastructure.Repositories.Contracts;

namespace WebApiSolveBank.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ContaBancariaController : ControllerBase
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        public ContaBancariaController(IContaBancariaRepository contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        [HttpGet("saldo/{contaId}")]
        public async Task<IActionResult> ConsultarSaldo(Guid contaId)
        {
            var saldoAtual = await _contaBancariaRepository.ConsultarSaldo(contaId);
            var okResult = new
            {
                contentType = "application/json",
                statusCode = 200,
                saldo = saldoAtual
            };
            return new ObjectResult(okResult);
        }

        [HttpGet("beneficiario/{numeroContaDestino}")]
        public async Task<IActionResult> BuscarBeneficiaro(int numeroContaDestino)
        {
            var nomeBeneficiario = _contaBancariaRepository.BuscarBeneficiario(numeroContaDestino);
            return Ok(nomeBeneficiario);
        }
    }
}
