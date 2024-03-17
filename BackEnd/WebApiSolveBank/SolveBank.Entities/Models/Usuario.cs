using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Enums;
using System.ComponentModel.DataAnnotations;


namespace SolveBank.Entities.Models
{
    public class Usuario : IdentityUser
    {
        public string NomeCompleto { get; set; }       
        public string CPF_CNPJ { get; set; } 
        public EnumTipoUsuario EnumTipoUsuario { get; set; }
        public List<ContaBancaria> ContasBancarias { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Removido { get; set; }
        public Usuario() { }
        public Usuario(
            string nomeCompleto,
            string cpf_cnpj,
            Endereco endereco,
            EnumTipoUsuario tipoUsuario,
            List<ContaBancaria> contasBancarias,
            DateTime dataCadastro,
            bool removido
            )
        {
            this.NomeCompleto = nomeCompleto;
            this.CPF_CNPJ = cpf_cnpj;            
            this.EnumTipoUsuario = tipoUsuario;
            this.ContasBancarias = contasBancarias;
            this.DataCadastro = dataCadastro;
            this.Removido = removido;
            DataCadastro = dataCadastro;
        }
    }
}
