using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class PagamentoService : ITransacaoRepository<TPagamento>
    {
        public Task<TPagamento> AgendarTransacao(TPagamento transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TPagamento>> ConsultarTransacaoAgendadas(Guid contaID)
        {
            throw new NotImplementedException();
        }

        public Task<List<TPagamento>> ConsultarTransacaoData(Guid contaID, DateTime dataSelecionada)
        {
            throw new NotImplementedException();
        }

        public Task<List<TPagamento>> ConsultarTransacaoPerirodo(Guid contaID, DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<List<TPagamento>> ConsultarTrasacoes(Guid contaID)
        {
            throw new NotImplementedException();
        }

        public Task<TPagamento> RealizarTransacao(TPagamento transacao)
        {
            throw new NotImplementedException();
        }
    }
}
