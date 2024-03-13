﻿using Microsoft.AspNetCore.Identity;
using SolveBank.Entities.Enums;
using System.ComponentModel.DataAnnotations;


namespace SolveBank.Entities.Models
{
    public class Usuario : IdentityUser
    {
        private string NomeCompleto { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "Nome deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 11)]
        private string CPF_CNPJ { get; set; }
        [Required]
        private Endereco Endereco { get; set; }
        [Required]
        private EnumTipoUsuario  EnumTipoUsuario { get; set; }
        [Required]
        private ContaBancaria ContaBancaria { get; set; }
        [Required]
        private DateTime DataCadastro {get; set; }
        [Required]
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
            this.DataCadastro=dataCadastro;
            this.Removido = removido;
            DataCadastro = dataCadastro;
        }
    }
}
