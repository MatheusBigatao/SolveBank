using SolveBank.Entities.Enums;
using SolveBank.Entities.Models;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface IUsuarioRepository
    {
        Task<Usuario>Cadastrar(Usuario usuario);
        Task<Usuario>AtualizarCadastro(Usuario usuario);
        Task<Usuario> Logar(string cpf, string senha);
        Task<EnumTipoUsuario> ConsultarTipoUsuario(string usuarioID);
        Task<bool> ExcluirCadastro(string usuarioID);        
    }
}
