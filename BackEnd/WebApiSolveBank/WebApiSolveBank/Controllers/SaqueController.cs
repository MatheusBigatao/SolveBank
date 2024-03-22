using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;

namespace WebApiSolveBank.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SaqueController : ControllerBase
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly ITransacaoRepository<TSaque> _transacaoRepository;
        public SaqueController(
            IContaBancariaRepository contaBancariaRepository,
            ITransacaoRepository<TSaque> transacaoRepository
            )
        {
            _contaBancariaRepository = contaBancariaRepository;
            _transacaoRepository = transacaoRepository;
        }

        [HttpPut("sacar/{contaId}")]
        public async Task<IActionResult> RealizarSaque(Guid contaId, [FromBody] decimal valorSaque)
        {
            var contaBancaria = await _contaBancariaRepository.ExibirDadosConta(contaId);
            var saldoDisponivel = contaBancaria.Saldo + contaBancaria.Limite - contaBancaria.LimiteUtilizado;
            if (contaBancaria.Saldo >= valorSaque)
            {
                contaBancaria.Saldo -= valorSaque;
            }
            else
            {
                var restante = valorSaque - contaBancaria.Saldo;
                contaBancaria.Saldo = 0;
                if (saldoDisponivel >= valorSaque)
                {
                    contaBancaria.LimiteUtilizado += restante;
                }
                else
                {
                    return BadRequest("Saldo da conta Insuficiente");
                }
            }

            var tSaqueRegister = new TSaque()
            {
                CodigoDoBanco = "302",
                ContaID = contaBancaria.Id,
                DataTransacao = DateTime.Now,
                Valor = valorSaque,
                LocalDoSaque = "Caixa Eletronico - 6458+FP Asa Norte, Brasília - DF "
            };

            await _transacaoRepository.RealizarTransacao(tSaqueRegister);
            await _contaBancariaRepository.AtualizarConta(contaBancaria);

            var okResult = new
            {
                contentType = "application/json",
                statusCode = 200,
                saldo = contaBancaria
            };
            return new ObjectResult(okResult);
        }
    }
}
