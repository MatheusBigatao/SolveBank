using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Configuration;
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
        private readonly SolveBankDbConfig _solveBankDbConfig;
        public DepositoService(SolveBankDbConfig solveBankDbConfig)
        {
            _solveBankDbConfig = solveBankDbConfig;
        }
        public Task<TDeposito> AgendarTransacao(TDeposito transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<TDeposito>> ConsultarTransacaoAgendadas(Guid contaID)
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

        public Task<List<TDeposito>> ConsultarTrasacoes(Guid contaID)
        {
            throw new NotImplementedException();
        }

        public async Task<TDeposito> RealizarTransacao(TDeposito transacao)
        {
            _solveBankDbConfig.Depositos.Add(transacao);
            await _solveBankDbConfig.SaveChangesAsync();
            return transacao;
        }
    }
}
