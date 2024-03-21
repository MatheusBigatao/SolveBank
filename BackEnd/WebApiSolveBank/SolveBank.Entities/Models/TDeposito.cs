


namespace SolveBank.Entities.Models
{
    public class TDeposito : Transacao
    {        
        public string Agencia { get; set; } = null!;
        public string NumeroDaConta{ get; set; } = null!;
        public string CodigoDoEnvelope { get; set; } = null!;
    }
}
