using System.ComponentModel.DataAnnotations;


namespace SolveBank.Entities.DTOs.Usuario
{
    public class RequestCriarUsuarioDTO
    {
        [Required]
        [StringLength(30, ErrorMessage = "Nome deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 3)]
        public string Nome { get; set; } = null!;
        [Required]
        [StringLength(30, ErrorMessage = "Nome deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 3)]
        public string Sobrenome { get; set; } = null!;
        [Required]
        [StringLength(18, ErrorMessage = "Nome deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 11)]
        public string  CPF_CNPJ { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(11, ErrorMessage ="Telefone deve conter no minímo 11 caracteres")]
        public string Telefone { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).+$", ErrorMessage = "A senha deve conter pelo menos uma letra e um número.")]
        public string Senha { get; set; } = null!;
        [Required]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).+$", ErrorMessage = "A Confirmacao senha deve conter pelo menos uma letra e um número.")]
        public string ConfirmarSenha { get; set; } = null!;
    }
}
