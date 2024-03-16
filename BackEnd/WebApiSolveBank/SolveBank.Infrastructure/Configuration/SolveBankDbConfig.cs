using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Models;

namespace SolveBank.Infrastructure.Configuration
{
    public class SolveBankDbConfig:IdentityDbContext<Usuario>
    {
        public SolveBankDbConfig(DbContextOptions<SolveBankDbConfig> options) : base (options)
        {
            
        }
        //Criaçao das Tabelas
        public DbSet<Atendimento> Atendimentos { get; set; }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Chaves Primarias
            builder.Entity<Atendimento>()
                .HasKey(a => a.Id);
            builder.Entity<Atendimento>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            //Chaves Estrangeiras
            builder.Entity<Transacao>()
                .HasOne(conta => conta.ContaBancaria)
                .WithMany()
                .HasForeignKey(conta => conta.ContaID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
