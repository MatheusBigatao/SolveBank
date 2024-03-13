using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class Transacao
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("ContaBancaria")]
        public Guid ContaID { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; } = null!;
        [Required]
        [StringLength(3, ErrorMessage = "Código do banco precisa ter no mínimo {2} caracteres e no máximo {1}", MinimumLength = 3)]
        public string CodigoDoBanco { get; set; } = null!;
        [Required]
        public decimal Valor { get; set; }
        public DateTime DataTransacao { get; set; }
    }
}
