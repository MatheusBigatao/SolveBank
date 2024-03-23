using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveBank.Entities.Models;
using SolveBank.Entities.DTOs.TransacoesDTOs.Saque;
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
        public async Task<IActionResult> RealizarSaque(Guid contaId, [FromBody] SaqueDTO saqueDTO)
        {
            var valorSaque = saqueDTO.ValorSaque;
            var contaBancariaSaque = await _contaBancariaRepository.ExibirDadosConta(contaId);
            if (contaBancariaSaque == null) return BadRequest("Conta bancária Não Localizada");
            var saldoDisponivel = contaBancariaSaque.Saldo + contaBancariaSaque.Limite - contaBancariaSaque.LimiteUtilizado;
            if (contaBancariaSaque.Saldo >= valorSaque)
            {
                contaBancariaSaque.Saldo -= valorSaque;
            }
            else
            {
                var restante = valorSaque - contaBancariaSaque.Saldo;
                contaBancariaSaque.Saldo = 0;
                if (saldoDisponivel >= valorSaque)
                {
                    contaBancariaSaque.LimiteUtilizado += restante;
                }
                else
                {
                    return BadRequest("Saldo da conta Insuficiente");
                }
            }

            var tSaqueRegister = new TSaque()
            {
                CodigoDoBanco = "302",
                ContaID = contaBancariaSaque.Id,
                DataTransacao = DateTime.Now,
                Valor = valorSaque,
                LocalDoSaque = "Caixa Eletronico - 6458+FP Asa Norte, Brasília - DF "
            };

            await _transacaoRepository.RealizarTransacao(tSaqueRegister);
            await _contaBancariaRepository.AtualizarConta(contaBancariaSaque);

            var respostaSaque = new
            {
                contentType = "application/json",
                statusCode = 200,
                contaBancaria = contaBancariaSaque
            };
            return new ObjectResult(respostaSaque);
        }
    }
}
