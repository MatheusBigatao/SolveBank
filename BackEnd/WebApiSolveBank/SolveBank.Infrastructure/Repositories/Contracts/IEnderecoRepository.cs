using SolveBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Contracts
{
    public interface IEnderecoRepository
    {
        Task<Endereco> CadastrarEndereco(Endereco endereco);
        Task<bool> RemoverEndereco(string enderecoID);
        Task<Endereco> GetEndereco(string enderecoID);
        Task<Endereco> AtualizarEndereco(Endereco endereco, string enderecoID);
    }
}
