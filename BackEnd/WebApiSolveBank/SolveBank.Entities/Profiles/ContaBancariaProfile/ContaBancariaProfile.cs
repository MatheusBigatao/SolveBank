using AutoMapper;
using SolveBank.Entities.DTOs.ContaBancariaDTOs;
using SolveBank.Entities.Models;

namespace SolveBank.Entities.Profiles.ContaBancariaProfile
{
    public class ContaBancariaProfile:Profile
    {
        public ContaBancariaProfile()
        {
            CreateMap<ContaBancaria, ResponseContaBancariaDTO>();
        }
    }
}
