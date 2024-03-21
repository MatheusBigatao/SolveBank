using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.ExternalServices.Contracts
{
    public interface IEmailRepository
    {
        Task SendToEmail(string body, string emailDestination);
    }
}
