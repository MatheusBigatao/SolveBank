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
    public class ContaBancariaService : IContaBancariaRepository
    {
        private readonly SolveBankDbConfig _solveBankDbConfig;
        public ContaBancariaService(SolveBankDbConfig solveBankDbConfig)
        {
            _solveBankDbConfig = solveBankDbConfig;
        }
        public Task<ContaBancaria> AtualizarConta(ContaBancaria contaBancaria)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> ConsultarSaldo(Guid contaBancariaID)
        {
            throw new NotImplementedException();
        }

        public async Task<ContaBancaria> CriarConta(ContaBancaria contaBancaria)
        {
            try
            {
                _solveBankDbConfig.ContasBancarias.Add(contaBancaria);
                await _solveBankDbConfig.SaveChangesAsync();
                return contaBancaria;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
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
