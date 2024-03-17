using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class Autenticacao2FatoresService : IAutenticacao2FatoresRepository
    {
        public Task<bool> AtualizarAutenticacao(Guid autenticacaoID, bool utilizado)
        {
            throw new NotImplementedException();
        } 

        public Task<Autenticacao2Fatores> CriarAutenticacao(Autenticacao2Fatores autenticacao2Fatores)
        {
            throw new NotImplementedException();
        }
    }
}
