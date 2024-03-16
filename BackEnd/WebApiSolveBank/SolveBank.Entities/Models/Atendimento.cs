using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SolveBank.Entities.Enums;


namespace SolveBank.Entities.Models
{    
    public class Atendimento
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("ContaBancaria")]
        public Guid ContaID { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; } = null!;

        public DateTime DataSolicitacao { get; set; }
        public DateTime DataUltimaResposta { get; set; }
        public EnumStatusAtendimento StatusAtendimento { get; set; }
        public virtual List<Mensagem> Mensagens { get; set; }= null!;

    }
}
