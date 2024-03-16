using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolveBank.Entities.Models
{
    public class TDeposito : Transacao
    {
        [ForeignKey("Transacao")]
        public Guid TransacaoID { get; set; }
        public virtual Transacao Transacao {get; set;} = null!;
        public string Agencia { get; set; } = null!;
        public string NumeroDaConta{ get; set; } = null!;
        public string CodigoDoEnvelope { get; set; } = null!;
    }
}
