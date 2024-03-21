using SolveBank.Entities.Models;


namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface IContaBancariaRepository
    {
        Task<ContaBancaria?>CriarConta(ContaBancaria contaBancaria);
        Task<decimal?> ConsultarSaldo(Guid contaBancariaID);
        Task<ContaBancaria> ExibirDadosConta(Guid contaBancariaID);
        Task<bool> DesativarAtivarConta(Guid contaBancariaID);
        Task<ContaBancaria?>AtualizarConta(ContaBancaria contaBancaria);
    }
}
