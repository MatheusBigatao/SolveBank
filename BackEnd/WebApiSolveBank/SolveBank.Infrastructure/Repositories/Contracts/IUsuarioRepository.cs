using Microsoft.AspNetCore.Identity;
using SolveBank.Entities.Models;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        Task<string> Cadastrar(Usuario usuario, string senha);
        Task<Usuario> AtualizarCadastro(Usuario usuario);
        Task<Usuario?> Logar(string cpf, string senha);        
        Task<bool> ExcluirCadastro(string usuarioID);
        Task<Usuario?> BuscarUsuario(string usuarioID);
    }
}
