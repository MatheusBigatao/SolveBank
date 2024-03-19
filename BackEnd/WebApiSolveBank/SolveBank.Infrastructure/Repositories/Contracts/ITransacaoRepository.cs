using SolveBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface ITransacaoRepository<T>
    {
        Task<T>RealizarTransacao(T transacao);
        Task<T> AgendarTransacao(T transacao);
        Task<List<T>> ConsultarTrasacoes(Guid contaID);
        Task<List<T>> ConsultarTransacaoAgendadas(Guid contaID );
        Task<List<T>> ConsultarTransacaoPerirodo(Guid contaID, DateTime dataInicio, DateTime dataFim);
        Task<List<T>> ConsultarTransacaoData(Guid contaID, DateTime dataSelecionada);
    }
}
