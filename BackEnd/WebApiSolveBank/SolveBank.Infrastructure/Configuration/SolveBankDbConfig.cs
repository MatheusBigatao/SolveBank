using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Models;

namespace SolveBank.Infrastructure.Configuration
{
    public class SolveBankDbConfig:IdentityDbContext<Usuario>
    {
        public SolveBankDbConfig(DbContextOptions<SolveBankDbConfig> options) : base (options)
        {
            
        }
    }
}
