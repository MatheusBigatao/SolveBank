using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class TPagamento : Transacao
    {
        [ForeignKey("Transacao")]
        public Guid TransacaoID { get; set; }
        public virtual Transacao Transacao {get; set;} = null!;
        
        public string Beneficiario { get; set; } = null!;
        public string NumeroBoleto { get; set; } = null!;
    }
}
