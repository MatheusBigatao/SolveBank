using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Configuration;
using SolveBank.Infrastructure.Repositories.Contracts;


namespace SolveBank.Infrastructure.Repositories.Services
{
    public class TransferenciaService : ITransacaoRepository<TTransferencia>
    {
        private readonly SolveBankDbConfig _solveBankDbConfig;
        public TransferenciaService(SolveBankDbConfig solveBankDbConfig)
        {
            _solveBankDbConfig = solveBankDbConfig;
        }

        public Task<TTransferencia> AgendarTransacao(TTransferencia transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TTransferencia>> ConsultarTransacaoAgendadas(Guid contaID)
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

        public Task<List<TTransferencia>> ConsultarTrasacoes(Guid contaID)
        {
            throw new NotImplementedException();
        }

        public async Task<TTransferencia> RealizarTransacao(TTransferencia transacao)
        {
            _solveBankDbConfig.Transferencias.Add(transacao);
            await _solveBankDbConfig.SaveChangesAsync();
            return transacao;
        }
    }
}
