using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class Autenticacao2Fatores
    {
        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime DataExpiracao { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public bool Utilizado { get; set; }
    }
}
