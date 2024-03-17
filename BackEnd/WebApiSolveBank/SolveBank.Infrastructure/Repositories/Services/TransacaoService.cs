﻿using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class TransacaoService : ITransacaoRepository<Transacao>
    {
        public Task<Transacao> AgendarTransacao(Transacao transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultarTransacaoAgendadas(Transacao transacao)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultarTransacaoData(Guid contaID, DateTime dataSelecionada)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultarTransacaoPerirodo(Guid contaID, DateTime dataInicio, DateTime dataFim)
        {
            throw new NotImplementedException();
        }

        public Task<List<Transacao>> ConsultarTrasacoes(Transacao transacao)
        {
            throw new NotImplementedException();
        }

        public Task<Transacao> RealizarTransacao(Transacao transacao)
        {
            throw new NotImplementedException();
        }
    }
}
