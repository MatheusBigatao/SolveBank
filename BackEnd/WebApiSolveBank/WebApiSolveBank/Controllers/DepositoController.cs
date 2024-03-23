using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveBank.Entities.DTOs.TransacoesDTOs.Deposito;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;

namespace WebApiSolveBank.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class DepositoController : ControllerBase
    {
        private readonly ITransacaoRepository<TDeposito> _transacaoRepository;
        private readonly IContaBancariaRepository _contaBancariaRepository;
        public DepositoController(
            ITransacaoRepository<TDeposito> transacaoRepository,
            IContaBancariaRepository contaBancariaRepository
            )
        {
            _transacaoRepository = transacaoRepository;
            _contaBancariaRepository = contaBancariaRepository;

        }
        [HttpPut("depositar/{contaId}")]
        public async Task<IActionResult> RealizarDeposito(Guid contaId, [FromBody] DepositoDTO depositoDTO)
        {
            var contaBancariaDeposito = await _contaBancariaRepository.ExibirDadosConta(contaId);
            if (contaBancariaDeposito == null) return BadRequest("Conta Bancária não encontrada");

            if (contaBancariaDeposito.LimiteUtilizado > 0)
            {
                if (contaBancariaDeposito.LimiteUtilizado >= depositoDTO.ValorDeposito)
                {
                    contaBancariaDeposito.LimiteUtilizado -= depositoDTO.ValorDeposito;
                }
                else if (contaBancariaDeposito.LimiteUtilizado < depositoDTO.ValorDeposito)
                {
                    var valorRestante = depositoDTO.ValorDeposito - contaBancariaDeposito.LimiteUtilizado;
                    contaBancariaDeposito.LimiteUtilizado = 0;
                    contaBancariaDeposito.Saldo += valorRestante;
                }
            }
            else
            {
                contaBancariaDeposito.Saldo += depositoDTO.ValorDeposito;
            }
            var transacaoDeposito = new TDeposito()
            {
                ContaID = contaBancariaDeposito.Id,
                DataTransacao = DateTime.Now,
                CodigoDoBanco = "302",
                Valor = depositoDTO.ValorDeposito,
                CodigoDoEnvelope = depositoDTO.CodigoEnvelope,
                Agencia = contaBancariaDeposito.Agencia,
                NumeroDaConta = contaBancariaDeposito.Numero,
            };
            await _transacaoRepository.RealizarTransacao(transacaoDeposito);
            await _contaBancariaRepository.AtualizarConta(contaBancariaDeposito);

            var respostaDeposito = new
            {
                contentType = "application/json",
                statusCode = 200,
                contaBancaria = contaBancariaDeposito
            };
            return new ObjectResult(respostaDeposito);
        }
    }
}
