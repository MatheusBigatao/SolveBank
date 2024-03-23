

namespace SolveBank.Entities.Models
{
    public class TDeposito : Transacao
    {        
        public string Agencia { get; set; } = null!;
        public long NumeroDaConta { get; set; } 
        public string CodigoDoEnvelope { get; set; } = null!;
    }
}
