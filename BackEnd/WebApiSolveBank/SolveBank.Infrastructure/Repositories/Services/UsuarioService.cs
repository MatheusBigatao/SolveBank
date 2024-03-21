using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Enums;
using SolveBank.Entities.Models;
using SolveBank.Infrastructure.Configuration;
using SolveBank.Infrastructure.Repositories.Contracts;


namespace SolveBank.Infrastructure.Repositories.Services
{
    public class UsuarioService : IUsuarioRepository
    {
        private readonly SolveBankDbConfig _solveBankDbConfig;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _sigInManager;
        private readonly IAutenticacao2FatoresRepository _autenticacao2Fatores;
        private static readonly Random random = new Random();
        public UsuarioService(
            SolveBankDbConfig solveBankDbConfig,
            SignInManager<Usuario> sigInManager,
            UserManager<Usuario> userManager,
            IAutenticacao2FatoresRepository autenticacao2Fatores
            )
        {
            _solveBankDbConfig = solveBankDbConfig;
            _sigInManager = sigInManager;
            _userManager = userManager;
            _autenticacao2Fatores = autenticacao2Fatores;

        }

        public async Task<Usuario> AtualizarCadastro(Usuario usuario)
        {
            _solveBankDbConfig.Usuarios.Update(usuario);
            await _solveBankDbConfig.SaveChangesAsync();
            return usuario;
        }

        public async Task<string> Cadastrar(Usuario usuario, string senha)
        {            
            try
            {
               var resultCreateUser = await _userManager.CreateAsync(usuario, senha);
                if (resultCreateUser.Succeeded)
                {
                    var newUser = await _userManager.FindByNameAsync(usuario.UserName);
                    var userId = newUser.Id;
                    return userId;
                }
                throw new Exception(resultCreateUser.Errors.ToString());
            }
            catch(Exception ex) 
            {
                return ex.Message;
            }
        }

        public async Task<bool> ExcluirCadastro(string usuarioID)
        {
            var usuario = await _solveBankDbConfig.Usuarios.FindAsync(usuarioID);
            if (usuario == null)
                return false;
            usuario.Removido = true;
            _solveBankDbConfig.Usuarios.Update(usuario);
            await _solveBankDbConfig.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario?> Logar(string cpf, string senha)
        {
            var usuarioEncontrado = await _solveBankDbConfig.Usuarios.FirstOrDefaultAsync(u => u.CPF_CNPJ == cpf);
            if (usuarioEncontrado != null)
            {
                var result = await _sigInManager.PasswordSignInAsync(usuarioEncontrado, senha, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var autenticacao2farotes = new Autenticacao2Fatores()
                    {
                        Token = random.Next(10000000, 99999999).ToString(),
                        UsuarioID = usuarioEncontrado.Id,
                        DataExpiracao = DateTime.UtcNow.AddMinutes(30),
                        Utilizado = false
                    };
                    var envioAutenticacao = await _autenticacao2Fatores.CriarAutenticacao(autenticacao2farotes);                                        
                    return usuarioEncontrado;
                }
                return null;
            }
            return null;
        }
        public async Task<Usuario?> BuscarUsuario(string usuarioID)
        {
            return await _solveBankDbConfig.Usuarios.FindAsync(usuarioID);
        }
    }
}
