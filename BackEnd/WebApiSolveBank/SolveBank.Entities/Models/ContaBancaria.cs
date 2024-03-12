using SolveBank.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class ContaBancaria
    {
        [Key]
        public Guid Id { get; set; }
        public string Agencia { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public List<Transacao> Transacoes { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public List<Cartao> Cartoes { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
        public EnumCategoriaConta EnumCategoriaConta { get; set; }
        public string Informacoes { get; set; }
    }
}
