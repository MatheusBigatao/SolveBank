using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class Endereco
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }
        public virtual Usuario Usuario {  get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Numero  { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string  CEP { get; set; }
        [Required]
        public string Estado { get; set; }       
        public string Complemento { get; set; }
    }
}
