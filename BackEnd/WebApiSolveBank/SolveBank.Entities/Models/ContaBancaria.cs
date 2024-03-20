using SolveBank.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolveBank.Entities.Models
{
    public class ContaBancaria
    {
        [Key]
        public Guid Id { get; set; }
        public string Agencia { get; set; } = null!;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int Numero { get; set; }
        public decimal Saldo { get; set; }
        public decimal Limite { get; set; }
        public virtual List<Transacao> Transacoes { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
        public List<Cartao> Cartoes { get; set; }
        public List<Atendimento> Atendimentos { get; set; }
        public EnumCategoriaConta EnumCategoriaConta { get; set; }
        public string Informacoes { get; set; } = null!;
        public bool Removido { get; set; }
    }
}
