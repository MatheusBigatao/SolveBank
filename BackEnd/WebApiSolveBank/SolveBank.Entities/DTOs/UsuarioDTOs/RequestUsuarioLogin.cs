using System.ComponentModel.DataAnnotations;


namespace SolveBank.Entities.DTOs.UsuarioDTOs
{
    public class RequestUsuarioLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
