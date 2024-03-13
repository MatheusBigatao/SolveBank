
namespace SolveBank.Entities.Models
{
    public class TPagamento : Transacao
    {
        public string Beneficiario { get; set; } = null!;
        public string NumeroBoleto { get; set; } = null!;
    }
}
