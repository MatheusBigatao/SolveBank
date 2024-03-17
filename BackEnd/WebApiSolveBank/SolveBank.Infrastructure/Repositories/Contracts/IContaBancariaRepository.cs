using SolveBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface IContaBancariaRepository
    {
        Task<ContaBancaria>CriarConta(ContaBancaria contaBancaria);
        Task<decimal> ConsultarSaldo(Guid contaBancariaID);
        Task<ContaBancaria> ExibirDadosConta(Guid contaBancariaID);
        Task<bool> DesativarAtivarConta(Guid contaBancariaID);
        Task<ContaBancaria>AtualizarConta(ContaBancaria contaBancaria);
    }
}
