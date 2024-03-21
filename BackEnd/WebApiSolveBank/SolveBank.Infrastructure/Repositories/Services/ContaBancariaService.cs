using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Enums;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Configuration;
using SolveBank.Infrastructure.Repositories.Contracts;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class ContaBancariaService : IContaBancariaRepository
    {
        private readonly SolveBankDbConfig _solveBankDbConfig;

        public ContaBancariaService(SolveBankDbConfig solveBankDbConfig)
        {
            _solveBankDbConfig = solveBankDbConfig;
        }

        public async Task<ContaBancaria?> AtualizarConta(ContaBancaria contaBancaria)
        {
            try{
                _solveBankDbConfig.ContasBancarias.Update(contaBancaria);
                await _solveBankDbConfig.SaveChangesAsync();
                return contaBancaria;
            }catch{
                return null;
            }
            
        }

        public async Task<decimal?> ConsultarSaldo(Guid contaBancariaID)
        {
            ContaBancaria contaBancaria = await _solveBankDbConfig.ContasBancarias.FindAsync(contaBancariaID);
            if (contaBancaria == null){
                return null;
            }
            return contaBancaria.Saldo;
        }

        public async Task<ContaBancaria> CriarConta(ContaBancaria contaBancaria)
        {
            var contaCriada = await _solveBankDbConfig.ContasBancarias.AddAsync(contaBancaria);
            await _solveBankDbConfig.SaveChangesAsync();
            return contaCriada.Entity;
        }

        public async Task<bool> DesativarAtivarConta(Guid contaBancariaID)
        {
            var contaBancaria = await _solveBankDbConfig.ContasBancarias.FindAsync(contaBancariaID);
            if (contaBancaria == null)
                return false;
            contaBancaria.Removido = true;
            _solveBankDbConfig.ContasBancarias.Update(contaBancaria);
            await _solveBankDbConfig.SaveChangesAsync();
            return true;
        }

        public async Task<ContaBancaria> ExibirDadosConta(Guid contaBancariaID)
        {
            var contaBancaria = await _solveBankDbConfig.ContasBancarias.FindAsync(contaBancariaID);
            return contaBancaria;
        }
    }
}
