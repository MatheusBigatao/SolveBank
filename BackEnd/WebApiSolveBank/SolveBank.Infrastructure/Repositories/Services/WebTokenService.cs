using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class WebTokenService : IWebTokenRepository
    {
        public Task<WebToken> CadastrarToken(string usuarioID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirToken(string tokenID)
        {
            throw new NotImplementedException();
        }
    }
}
