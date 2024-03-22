using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Configuration;
using SolveBank.Infrastructure.Repositories.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace SolveBank.Infrastructure.Repositories.Services
{
    public class WebTokenService : IWebTokenRepository
    {
        private readonly IConfiguration _configuration;        
        private readonly IUsuarioRepository _usuarioRepository;

        public WebTokenService(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;            
            _usuarioRepository = usuarioRepository;
        }

        public async Task<WebToken> CadastrarToken(string usuarioID)
        {
            var usuarioLogin = await _usuarioRepository.BuscarUsuario(usuarioID);
            if (usuarioLogin != null)
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuarioLogin.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var expirationGet = _configuration["TokenConfiguration:ExpireMinutes"];
                var expiration = DateTime.Now.AddMinutes(double.Parse(expirationGet));

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["TokenConfiguration:Issuer"],
                    audience: _configuration["TokenConfiguration:Audience"],
                    claims: claims,
                    expires: expiration,
                    signingCredentials: credentials
                    );

                var tokenCreated = new WebToken()
                {
                    DataCriado = DateTime.UtcNow,
                    UsuarioID = usuarioLogin.Id,
                    ExpiracaoToken = expiration,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),

                };
                return tokenCreated;
            }
            throw new Exception("Usuário não localziado");
        }
    }
}
