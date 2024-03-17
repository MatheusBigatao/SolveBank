using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class TransferenciaService : ITransacaoRepository<TTransferencia>
    {
        public Task<TTransferencia> AgendarTransacao(TTransferencia transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TTransferencia>> ConsultarTransacaoAgendadas(TTransferencia transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TTransferencia>> ConsultarTransacaoData(Guid contaID, DateTime dataSelecionada)
        {
            throw new NotImplementedException();
        }

        public Task<List<TTransferencia>> ConsultarTransacaoPerirodo(Guid contaID, DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<List<TTransferencia>> ConsultarTrasacoes(TTransferencia transacao)
        {
            throw new NotImplementedException();
        }

        public Task<TTransferencia> RealizarTransacao(TTransferencia transacao)
        {
            throw new NotImplementedException();
        }
    }
}
