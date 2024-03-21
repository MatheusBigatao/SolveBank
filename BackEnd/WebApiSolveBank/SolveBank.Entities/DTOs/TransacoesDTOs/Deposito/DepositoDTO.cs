using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolveBank.Entities.DTOs.TransacoesDTOs.Deposito
{
    public class DepositoDTO
    {
        public decimal ValorDeposito { get; set; }
        public string CodigoEnvelope { get; set; }
        
    }
}
