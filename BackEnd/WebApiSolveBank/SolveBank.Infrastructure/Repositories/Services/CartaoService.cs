using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class CartaoService : ICartaoRepository
    {
        public Task<bool> BloquearCartao(Guid cartaoID, decimal novoLimite)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BloquearDesbloquearCartao(string cartaoID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cartao>> BuscarCartao(Guid contaID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreditarTaxaCashBack(Cartao cartao, decimal valorCashBack)
        {
            throw new NotImplementedException();
        }

        public Task<Cartao> CriarCartao(Cartao cartao)
        {
            throw new NotImplementedException();
        }
    }
}
