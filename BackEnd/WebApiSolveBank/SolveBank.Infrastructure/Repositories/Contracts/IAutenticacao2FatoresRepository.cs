using SolveBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface IAutenticacao2FatoresRepository
    {
        Task<Autenticacao2Fatores> CriarAutenticacao(Autenticacao2Fatores autenticacao2Fatores);
        Task<bool>AtualizarAutenticacao(Guid autenticacaoID, bool utilizado);
    }
}
