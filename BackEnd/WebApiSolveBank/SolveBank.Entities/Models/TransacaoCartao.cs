using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class TransacaoCartao
    {
        public Guid Id { get; set; }
        [ForeignKey("Transacao")]
        public Guid TransacaoID { get; set;}
        public virtual Transacao Transacao { get; set; } = null!;
        [ForeignKey("Cartao")]
        public Guid MyProperty { get; set; }
        public virtual Cartao Cartao { get; set; } = null!;
    }
}
