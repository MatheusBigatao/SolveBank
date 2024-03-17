using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class ContaBancariaService : IContaBancariaRepository
    {
        public Task<ContaBancaria> AtualizarConta(ContaBancaria contaBancaria)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> ConsultarSaldo(Guid contaBancariaID)
        {
            throw new NotImplementedException();
        }

        public Task<ContaBancaria> CriarConta(ContaBancaria contaBancaria)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DesativarAtivarConta(Guid contaBancariaID)
        {
            throw new NotImplementedException();
        }

        public Task<ContaBancaria> ExibirDadosConta(Guid contaBancariaID)
        {
            throw new NotImplementedException();
        }
    }
}
