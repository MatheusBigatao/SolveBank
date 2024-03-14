using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolveBank.Entities.Models
{    
    public class Atendimento
    {
        [Key]
        public Guid Id { get; set; }
    }
}
