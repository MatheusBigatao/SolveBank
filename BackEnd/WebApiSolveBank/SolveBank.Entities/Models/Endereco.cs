using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolveBank.Entities.Models
{
    public class Endereco
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; } = null!;
        public virtual Usuario Usuario {  get; set; } = null!;
        [Required]
        public string Logradouro { get; set; } = null!;
        [Required]
        public string Cidade { get; set; } = null!;
        [Required]
        public string Numero  { get; set; } = null!;
        [Required]
        public string Bairro { get; set; } = null!;
        [Required]
        public string  CEP { get; set; } = null!;
        [Required]
        public string Estado { get; set; } = null!;
        public string Complemento { get; set; } = null!;
    }
}
