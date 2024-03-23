using SolveBank.Entities.Enums;
using SolveBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.DTOs.ContaBancariaDTOs
{
    public class ResponseContaBancariaDTO
    {       
        public Guid Id { get; set; }
        public string Agencia { get; set; } = null!;
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }    
        public decimal LimiteUtilizado { get; set; }
        public virtual List<Transacao> Transacoes { get; set; }
        public string UsuarioID { get; set; } = null!;        
        public List<Cartao> Cartoes { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
        public EnumCategoriaConta EnumCategoriaConta { get; set; }
        public string Informacoes { get; set; } = null!;
        public bool Removido { get; set; }
    }
}
