using System.ComponentModel.DataAnnotations;


namespace SolveBank.Entities.DTOs.Usuario
{
    public class RequestCriarUsuario()
    {
        [Required]
        [StringLength(30, ErrorMessage = "Nome deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 5)]
        [RegularExpression("^[A-Za-z]+(?: [A-Za-z]+)+$")]
        public string Nome { get; set; } = null!;
        [Required]
        [StringLength(30, ErrorMessage = "Nome deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 5)]
        [RegularExpression("(?:\\s[A-ZÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ][a-záàâãéèêíïóôõöúçñ]+)?")]
        public string Sobrenome { get; set; } = null!;
        [Required]
        [StringLength(18, ErrorMessage = "Nome deve conter no máximo {1} e no mínimo {2} caracteres", MinimumLength = 11)]
        public string  CPF_CNPJ { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).+$", ErrorMessage = "A senha deve conter pelo menos uma letra e um número.")]
        public string Senha { get; set; } = null!;
        [Required]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d).+$", ErrorMessage = "A Confirmacao senha deve conter pelo menos uma letra e um número.")]
        public string ConfirmaSenha { get; set; } = null!;
    }
}
