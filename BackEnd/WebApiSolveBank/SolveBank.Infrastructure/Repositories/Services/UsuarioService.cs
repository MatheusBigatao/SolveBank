using SolveBank.Entities.Enums;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class UsuarioService : IUsuarioRepository
    {
        public Task<Usuario> AtualizarCadastro(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Cadastrar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<EnumTipoUsuario> ConsultarTipoUsuario(string usuarioID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExcluirCadastro(string usuarioID)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Logar(string cpf, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
