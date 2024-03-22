


namespace SolveBank.Entities.Models
{
    public class TDeposito : Transacao
    {        
        public string Agencia { get; set; } = null!;
        public int NumeroDaConta{ get; set; } 
        public string CodigoDoEnvelope { get; set; } = null!;
    }
}
