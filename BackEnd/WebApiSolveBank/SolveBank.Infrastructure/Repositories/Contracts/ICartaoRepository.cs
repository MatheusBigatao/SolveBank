using SolveBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface ICartaoRepository
    {
        Task<Cartao> CriarCartao(Cartao cartao);
        Task<bool> BloquearDesbloquearCartao(string cartaoID);
        Task<bool> BloquearCartao(Guid cartaoID, decimal novoLimite);
        Task<List<Cartao>> BuscarCartao(Guid contaID);
        Task<bool>CreditarTaxaCashBack(Cartao cartao, decimal valorCashBack);
    }
}
