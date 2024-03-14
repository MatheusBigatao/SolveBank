using Microsoft.AspNetCore.Identity;
using SolveBank.Entities.Enums;

namespace SolveBank.Entities.Models
{
    public class Usuario : IdentityUser
    {
        private string NomeCompleto { get; set; }
        private string CPF_CNPJ { get; set; }
        private Endereco Endereco { get; set; }
        private EnumTipoUsuario EnumTipoUsuario { get; set; }
        private ContaBancaria ContaBancaria { get; set; }
        private DateTime DataCadastro { get; set; }
        private bool Removido { get; set; }
        public Usuario(
            string nomeCompleto,
            string cpf_cnpj,
            Endereco endereco,
            EnumTipoUsuario tipoUsuario,
            ContaBancaria contaBancaria,
            DateTime dataCadastro,
            bool removido
            )
        {
            this.NomeCompleto = nomeCompleto;
            this.CPF_CNPJ = cpf_cnpj;
            this.Endereco = endereco;
            this.EnumTipoUsuario = tipoUsuario;
            this.ContaBancaria = contaBancaria;
            this.DataCadastro = dataCadastro;
            this.Removido = removido;
            DataCadastro = dataCadastro;
        }
    }
}
