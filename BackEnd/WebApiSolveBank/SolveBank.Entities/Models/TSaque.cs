using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class TSaque : Transacao
    {
       [Required]
       public string LocalDoSaque { get; set; }   
    }
}
