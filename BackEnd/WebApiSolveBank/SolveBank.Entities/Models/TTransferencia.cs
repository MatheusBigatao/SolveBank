using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class TTransferencia : Transacao
    {
        public string Beneficiario { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = " AgenciaDestino deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 4)]
        public string AgenciaDestino { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "NumeroContaDestino deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 4)]
        public string NumeroContaDestino { get; set; }
        [Required]
        [MinLength(4,ErrorMessage = "ContaOrigem precisa ter no mínimo 4 caracteres")]
        public string ContaOrigem { get; set; }
    }
}
