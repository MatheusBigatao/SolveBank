using System.ComponentModel.DataAnnotations;


namespace SolveBank.Entities.DTOs.UsuarioDTOs
{
    public class RequestUsuarioLogin
    {
        [Required]        
        public string Cpf_Cnpj { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
