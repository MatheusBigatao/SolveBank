using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class TTransferencia : Transacao
    {
        
        public string Beneficiario { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = " AgenciaDestino deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 4)]
        public string AgenciaDestino { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = "NumeroContaDestino deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 4)]
        public int NumeroContaDestino { get; set; }
        [Required]
        [MinLength(4,ErrorMessage = "ContaOrigem precisa ter no mínimo 4 caracteres")]
        public int ContaOrigem { get; set; } 
    }
}
