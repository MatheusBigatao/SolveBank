using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class EmailConfiguracao
    {
        [Required]
        public string ServerSmtp { get; set; } = null!;
        [Required]
        public int Port { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public bool EnableSsl { get; set; }
        public string EmailFromAddress { get; set; } = null!;
        public string EmailDestination { get; set; } = null!;
    }
}
