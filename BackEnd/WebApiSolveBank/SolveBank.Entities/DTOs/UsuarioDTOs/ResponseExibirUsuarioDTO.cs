using SolveBank.Entities.DTOs.ContaBancariaDTOs;
using SolveBank.Entities.Enums;
using SolveBank.Entities.Models;

namespace SolveBank.Entities.DTOs.UsuarioDTOs
{
    public class ResponseExibirUsuarioDTO
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public string CPF_CNPJ { get; set; }
        public EnumTipoUsuario EnumTipoUsuario { get; set; }
        public List<ResponseContaBancariaDTO> ContaBancarias { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Removido { get; set; }
        public WebToken WebToken { get; set; }
    }
}
