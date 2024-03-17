using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class SaqueService : ITransacaoRepository<TSaque>
    {
        public Task<TSaque> AgendarTransacao(TSaque transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TSaque>> ConsultarTransacaoAgendadas(TSaque transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TSaque>> ConsultarTransacaoData(Guid contaID, DateTime dataSelecionada)
        {
            throw new NotImplementedException();
        }

        public Task<List<TSaque>> ConsultarTransacaoPerirodo(Guid contaID, DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<List<TSaque>> ConsultarTrasacoes(TSaque transacao)
        {
            throw new NotImplementedException();
        }

        public Task<TSaque> RealizarTransacao(TSaque transacao)
        {
            throw new NotImplementedException();
        }
    }
}
