using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class Mensagem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("ContaBancaria")]
        public Guid ContaID { get; set; }

        [Required]
        [ForeignKey("Atendimento")]
        public Guid AtendimentoID { get; set; }
        public virtual Atendimento Atendimento { get; set; } = null!;
        public DateTime Data { get; set; }
        public string Conteudo { get; set; } = "";

    }
}
