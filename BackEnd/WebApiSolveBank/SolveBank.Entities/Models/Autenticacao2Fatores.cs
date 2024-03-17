using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolveBank.Entities.Models
{
    public class Autenticacao2Fatores
    {
        [Key]
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime DataExpiracao { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public bool Utilizado { get; set; }

        public string CreateEmailBody()
        {
            return $"<!DOCTYPE html>\r\n<html lang=\"pt-BR\">\r\n\r\n<head>\r\n " +
                $" <meta charset=\"UTF-8\">\r\n  <meta http-equiv=\"X-UA-Compatible\"" +
                $" content=\"IE=edge\">\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n" +
                $"  <title>Convite de Cadastro</title>\r\n" +
                $"  <style>\r\n    body {{\r\n " +
                $"     font-family: Arial, sans-serif;\r\n" +
                $"     margin: 0;\r\n      " +
                $"     padding: 0;\r\n" +
                $"     }}\r\n\r\n    " +
                $"     .container {{\r\n" +
                $"     max-width: 600px;\r\n" +
                $"     margin: 20px auto;\r\n " +
                $"     color: #FFFF;\r\n " +
                $"     background: #171A4A;\r\n " +
                $"     background: repeating-linear-gradient(to left, #171A4A 0%, #FF7D26 0%, #CF3A3A 100%);\r\n" +
                $"     padding: 20px;\r\n " +
                $"     border-radius: 5px;\r\n" +
                $"     box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n" +
                $"     }}\r\n\r\n " +
                $"     img {{\r\n" +
                $"     max-width: 100%;\r\n" +
                $"     height: auto;\r\n " +
                $"     display: block;\r\n" +
                $"     margin: 0 auto;\r\n  " +
                $"     }}\r\n\r\n" +
                $"    .invite-code {{\r\n" +
                $"     text-align: center;\r\n" +
                $"     font-size: 24px;\r\n" +
                $"     color: #007bff;\r\n " +
                $"     margin-top: 20px;\r\n " +
                $"     background: #FFFF;\r\n " +
                $"     border-radius: 5px;\r\n " +
                $"     }}\r\n " +
                $"     </style>\r\n</head>\r\n\r\n<body>\r\n" +
                $"     <div class=\"container\">\r\n" +
                $"     <img src=\"https://tscontrol.marcusvogado.com/assets/img/logo-codesolve.png\" alt=\"Logo da Empresa\">\r\n" +
                $"     <h1 style=\"text-align: center;\">SolveBank</h1> \r\n" +
                $"     <p>Olá,</p>\r\n " +
                $"     <p>O seu Código de Acesso ao SolveBank é:\r\n" +                     
                $"     <p class=\"invite-code\">{this.Token}</p>\r\n" +                
                $"  </div>\r\n" +
                $"</body>\r\n\r\n" +
                $"</html>";
        }
    }
}
