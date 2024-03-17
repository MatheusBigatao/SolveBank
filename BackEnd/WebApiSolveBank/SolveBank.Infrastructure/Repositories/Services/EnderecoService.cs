using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Infrastructure.Repositories.Services
{
    public class EnderecoService : IEnderecoRepository
    {
        public Task<Endereco> AtualizarEndereco(Endereco endereco, string enderecoID)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> CadastrarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> GetEndereco(string enderecoID)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverEndereco(string enderecoID)
        {
            throw new NotImplementedException();
        }
    }
}
