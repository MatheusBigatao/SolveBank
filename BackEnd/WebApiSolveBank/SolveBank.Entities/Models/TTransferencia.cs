using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class TTransferencia : Transacao
    {
        [Required]
        [ForeignKey("Transacao")]
        public Guid TransacaoID { get; set; }
        public virtual Transacao Transacao {get; set;} = null!;
        public string Beneficiario { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = " AgenciaDestino deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 4)]
        public string AgenciaDestino { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = "NumeroContaDestino deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 4)]
        public string NumeroContaDestino { get; set; } = null!;
        [Required]
        [MinLength(4,ErrorMessage = "ContaOrigem precisa ter no mínimo 4 caracteres")]
        public string ContaOrigem { get; set; } = null!;
    }
}
