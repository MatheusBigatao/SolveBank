using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class DepositoService : ITransacaoRepository<TDeposito>
    {
        public Task<TDeposito> AgendarTransacao(TDeposito transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDeposito>> ConsultarTransacaoAgendadas(TDeposito transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDeposito>> ConsultarTransacaoData(Guid contaID, DateTime dataSelecionada)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDeposito>> ConsultarTransacaoPerirodo(Guid contaID, DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDeposito>> ConsultarTrasacoes(TDeposito transacao)
        {
            throw new NotImplementedException();
        }

        public Task<TDeposito> RealizarTransacao(TDeposito transacao)
        {
            throw new NotImplementedException();
        }
    }
}
