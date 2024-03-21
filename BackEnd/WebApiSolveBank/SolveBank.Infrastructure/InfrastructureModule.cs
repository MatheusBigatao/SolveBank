using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SolveBank.Entities.Models;
using SolveBank.Entities.Profiles.UsuarioProfile;
using SolveBank.Infrastructure.Configuration;
using SolveBank.Infrastructure.ExternalServices.Contracts;
using SolveBank.Infrastructure.ExternalServices.Services;
using SolveBank.Infrastructure.Repositories.Contracts;
using SolveBank.Infrastructure.Repositories.Services;

namespace SolveBank.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddRepositories();            
            services.AddServices();
            services.AutoMapper();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddIdentity<Usuario, IdentityRole>()
                .AddEntityFrameworkStores<SolveBankDbConfig>()
                .AddDefaultTokenProviders();
            services.AddScoped<IUsuarioRepository, UsuarioService>();
            services.AddScoped<IContaBancariaRepository, ContaBancariaService>();
            services.AddScoped<IAutenticacao2FatoresRepository, Autenticacao2FatoresService>();
            services.AddScoped<IEnderecoRepository, EnderecoService>();
            services.AddScoped<ITransacaoRepository<TSaque>, SaqueService>();
            services.AddScoped<ITransacaoRepository<TDeposito>, DepositoService>();
            services.AddScoped<ITransacaoRepository<TTransferencia>, TransferenciaService>();
            services.AddScoped<IWebTokenRepository, WebTokenService>();
            
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailRepository, EmailService>();            
            return services;
        }
        private static IServiceCollection AutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(options =>
            {
                options.AddProfile<UsuarioProfile>();
            });

            return services;
        }
                
    }
}
