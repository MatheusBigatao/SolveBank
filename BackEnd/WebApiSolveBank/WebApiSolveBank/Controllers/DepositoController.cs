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
            var contaBancaria = await _contaBancariaRepository.ExibirDadosConta(contaId);
            if (contaBancaria == null) return BadRequest("Conta Bancária não encontrada");

            if (contaBancaria.LimiteUtilizado > 0)
            {
                if (contaBancaria.LimiteUtilizado >= depositoDTO.ValorDeposito)
                {
                    contaBancaria.LimiteUtilizado -= depositoDTO.ValorDeposito;
                }
                else if(contaBancaria.LimiteUtilizado < depositoDTO.ValorDeposito)
                {
                    var valorRestante =  depositoDTO.ValorDeposito - contaBancaria.LimiteUtilizado;
                    contaBancaria.LimiteUtilizado = 0;
                    contaBancaria.Saldo += valorRestante;                    
                }
            }
            else
            {
                contaBancaria.Saldo += depositoDTO.ValorDeposito;
            }
            var transacaoDeposito = new TDeposito()
            {
                ContaID = contaBancaria.Id,
                DataTransacao = DateTime.Now,
                CodigoDoBanco = "302",
                Valor = depositoDTO.ValorDeposito,
                CodigoDoEnvelope = depositoDTO.CodigoEnvelope,
                Agencia = contaBancaria.Agencia,
                NumeroDaConta = contaBancaria.Numero,
            };
            await _transacaoRepository.RealizarTransacao(transacaoDeposito);
            await _contaBancariaRepository.AtualizarConta(contaBancaria);
            return Ok(contaBancaria);
        }
    }
}
