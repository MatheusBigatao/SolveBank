using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolveBank.Entities.DTOs.TransacoesDTOs.Transferencia;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;

namespace WebApiSolveBank.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransacaoRepository<TTransferencia> _trasacaoRepository;
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public TransferenciaController
            (
            ITransacaoRepository<TTransferencia> transacaoRepository,
            IContaBancariaRepository contaBancariaRepository
            )
        {
            _trasacaoRepository = transacaoRepository;
            _contaBancariaRepository = contaBancariaRepository;
        }
        [HttpPut("transferir/{contaId}")]
        public async Task<IActionResult> RealizarTransferencia(Guid contaId, [FromBody] TransferenciaDTO transferenciaDTO)
        {
            var contaOrigem = await _contaBancariaRepository.ExibirDadosConta(contaId);
            var contaDestino = await _contaBancariaRepository.RetornaContaNumero(transferenciaDTO.NumeroContaDestino);
            if (contaOrigem == null || contaDestino == null) return BadRequest("Conta Bancária não encontrada");
            var saldoDisponivel = contaOrigem.Saldo + contaOrigem.Limite - contaOrigem.LimiteUtilizado;
            if (contaOrigem.Saldo >= transferenciaDTO.Valor)
            {
                contaOrigem.Saldo -= transferenciaDTO.Valor;
            }
            else
            {
                var restante = transferenciaDTO.Valor - contaOrigem.Saldo;
                contaOrigem.Saldo = 0;
                if (saldoDisponivel >= transferenciaDTO.Valor)
                {
                    contaOrigem.LimiteUtilizado += restante;
                }
                else
                {
                    return BadRequest("Saldo da conta Insuficiente");
                }
            }
            if (contaDestino.LimiteUtilizado > 0)
            {
                if (contaDestino.LimiteUtilizado >= transferenciaDTO.Valor)
                {
                    contaDestino.LimiteUtilizado -= transferenciaDTO.Valor;
                }
                else if (contaDestino.LimiteUtilizado < transferenciaDTO.Valor)
                {
                    var valorRestante = transferenciaDTO.Valor - contaDestino.LimiteUtilizado;
                    contaDestino.LimiteUtilizado = 0;
                    contaDestino.Saldo += valorRestante;
                }
            }
            else
            {
                contaDestino.Saldo += transferenciaDTO.Valor;
            }

            var transferencia = new TTransferencia()
            {
                DataTransacao = DateTime.Now,
                CodigoDoBanco = "302",
                Valor = transferenciaDTO.Valor,
                ContaID = contaOrigem.Id,
                ContaOrigem = contaOrigem.Numero,
                NumeroContaDestino= contaDestino.Numero,
                AgenciaDestino= "001",
                Beneficiario= transferenciaDTO.Beneficiario
            };
            await _trasacaoRepository.RealizarTransacao(transferencia);
            await _contaBancariaRepository.AtualizarConta(contaDestino);
            await _contaBancariaRepository.AtualizarConta(contaOrigem);
            return Ok(contaOrigem);
        }
    }
}
