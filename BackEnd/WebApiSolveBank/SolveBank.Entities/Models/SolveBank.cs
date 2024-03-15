using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class SolveBankModel
    {
        [Key]
        public Guid Id { get; set; }
        public string CodigoDoBanco { get; set; } = null!;
        public virtual List<Usuario>? Usuarios { get; set; }
    }
}
