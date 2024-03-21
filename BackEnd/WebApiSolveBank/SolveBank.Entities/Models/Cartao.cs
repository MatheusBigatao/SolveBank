using SolveBank.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolveBank.Entities.Models
{
    public class Cartao
    {
        [Key]
        public Guid Id { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime Validade { get; set; }
        public string CVV { get; set; } = null!;
        [ForeignKey("ContaBancaria")]
        public Guid ContaID { get; set; }
        public virtual ContaBancaria ContaBancaria { get; set; } = null!;
        public decimal Limite { get; set; }
        public decimal LimiteUtilizado { get; set; }
        public EnumTipoCartao EnumTipoCartao { get; set; }
        public EnumBandeiraCartao EnumBandeiraCartao { get; set; }
        public EnumCategoriaCartao EnumCategoriaCartao { get; set; }
        public virtual List<TransacaoCartao> TransacoesCartao { get; set; }
    }
}
