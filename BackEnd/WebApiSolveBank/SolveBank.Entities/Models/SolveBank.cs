using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class SolveBank
    {
        [Key]
        public Guid Id { get; set; }
        public string CodigoDoBanco { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
