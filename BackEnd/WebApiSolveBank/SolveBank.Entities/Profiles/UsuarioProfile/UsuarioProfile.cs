using AutoMapper;
using SolveBank.Entities.DTOs.UsuarioDTOs;
using SolveBank.Entities.Models;

namespace SolveBank.Entities.Profiles.UsuarioProfile
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, ResponseExibirUsuarioDTO>();
        }
    }
}
