using SolveBank.Entities.DTOs.UsuarioDTOs;
using SolveBank.Entities.Models;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface IAutenticacao2FatoresRepository
    {
        Task<bool> CriarAutenticacao(Autenticacao2Fatores autenticacao2Fatores);
        Task<ResponseExibirUsuarioDTO?> AutenticarUsuario(string autenticacaoToken);
    }
}
