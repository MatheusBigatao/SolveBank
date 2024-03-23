using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.DTOs.TransacoesDTOs.Transferencia
{
    public class TransferenciaDTO
    {
        public string Beneficiario { get; set; } = null!;
        [Required]
        [StringLength(20, ErrorMessage = " AgenciaDestino deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 4)]
        public string AgenciaDestino { get; set; } = null!;
        [Required]        
        public int NumeroContaDestino { get; set; }
        [Required]       
        public int ContaOrigem { get; set; }
        [Required]
        public decimal  Valor { get; set; }

    }
}
