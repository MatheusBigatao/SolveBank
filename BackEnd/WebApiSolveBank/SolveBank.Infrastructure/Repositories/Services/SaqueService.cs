using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Configuration;
using SolveBank.Infrastructure.Repositories.Contracts;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class SaqueService : ITransacaoRepository<TSaque>
    {
        private readonly SolveBankDbConfig _solveBankDbConfig;
        public SaqueService(SolveBankDbConfig solveBankDbConfig)
        {
            _solveBankDbConfig = solveBankDbConfig;
        }
        public Task<TSaque> AgendarTransacao(TSaque transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TSaque>> ConsultarTransacaoAgendadas(Guid contaID)
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

        public async Task<List<TSaque>> ConsultarTrasacoes(Guid contaID)
        {
            return await _solveBankDbConfig.Saques.Where(s => s.ContaID ==  contaID).ToListAsync();
        }

        public async Task<TSaque> RealizarTransacao(TSaque transacao)
        {
            _solveBankDbConfig.Saques.Add(transacao);
            await _solveBankDbConfig.SaveChangesAsync();
            return transacao;
        }
    }
}
