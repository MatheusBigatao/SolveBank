using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.Models
{
    public class TDeposito : Transacao
    {
        public string Agencia { get; set; }
        public string NumeroDaConta{ get; set; }
        public string CodigoDoEnvelope { get; set; }
    }
}
