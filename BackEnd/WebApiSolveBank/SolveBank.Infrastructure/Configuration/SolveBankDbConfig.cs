using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SolveBank.Entities.Models;
using System.Reflection.Emit;

namespace SolveBank.Infrastructure.Configuration
{
    public class SolveBankDbConfig : IdentityDbContext<Usuario>
    {
        public SolveBankDbConfig()
        {

        }

        public SolveBankDbConfig(DbContextOptions<SolveBankDbConfig> options) : base(options)
        {
            Database.Migrate();
        }


        //Criaçao das Tabelas
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Autenticacao2Fatores> Autenticacao2Fatores { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<SolveBankModel> SolveBank { get; set; }
        public DbSet<TDeposito> Depositos { get; set; }
        public DbSet<TPagamento> Pagamentos { get; set; }
        // public DbSet<TPix> Pixs { get; set; }  // --> TODO - IMPLEMENTAR PIX
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<TransacaoCartao> TransacoesCartoes { get; set; }
        public DbSet<TTransferencia> Transferencias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<WebToken> WebTokens { get; set; }
        public DbSet<TSaque> Saques { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Seguindo em ordem alfabética da pasta Models
            #region Atendimentos

            builder.Entity<Atendimento>()
                .HasKey(a => a.Id);
            builder.Entity<Atendimento>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Atendimento>()
                    .HasOne(atendimento => atendimento.ContaBancaria)
                    .WithMany(conta => conta.Atendimentos)
                    .HasForeignKey(c => c.ContaID)
                    .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Autenticacao2Fatores

            builder.Entity<Autenticacao2Fatores>().HasKey(a => a.Id);
            builder.Entity<Autenticacao2Fatores>().Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Entity<Autenticacao2Fatores>()
                .HasOne(a => a.Usuario)
                .WithMany()
                .HasForeignKey(usuario => usuario.UsuarioID)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Cartao

            builder.Entity<Cartao>().HasKey(c => c.Id);
            builder.Entity<Cartao>().Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Entity<Cartao>()
                .Property(cb => cb.Limite)
                .HasPrecision(18, 2);
            builder.Entity<Cartao>()
               .Property(cb => cb.LimiteUtilizado)
               .HasPrecision(18, 2);

            builder.Entity<Cartao>()
                .HasOne(c => c.ContaBancaria)
                .WithMany()
                .HasForeignKey(c => c.ContaID)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region ContasBancarias

            builder.Entity<ContaBancaria>()
                .HasKey(cb => cb.Id);
            builder.Entity<ContaBancaria>()
                .Property(cb => cb.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<ContaBancaria>()
                .Property(cb => cb.Saldo)
                .HasPrecision(18, 2);
            builder.Entity<ContaBancaria>()
                .Property(cb => cb.Limite)
            .HasPrecision(18, 2);
            builder.Entity<ContaBancaria>()
               .Property(cb => cb.LimiteUtilizado)
           .HasPrecision(18, 2);
            builder.Entity<ContaBancaria>()
              .HasIndex(cb => cb.Numero)
              .IsUnique(true);
            builder.Entity<ContaBancaria>()
              .Property(c => c.Numero)
              .HasMaxLength(8)
              .IsFixedLength();
            builder.Entity<ContaBancaria>()
              .Property(c => c.Numero)
              .ValueGeneratedOnAdd();

            builder.Entity<ContaBancaria>()
                .HasOne(cb => cb.Usuario)
                .WithMany(usuario => usuario.ContasBancarias)
                .HasForeignKey(cb => cb.UsuarioID)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Depositos
            builder.Entity<TPagamento>()
                .HasBaseType<Transacao>();
            #endregion

            #region Enderecos

            builder.Entity<Endereco>().HasKey(e => e.Id);
            builder.Entity<Endereco>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Endereco>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(u => u.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Mensagens
            builder.Entity<Mensagem>().HasKey(m => m.Id);
            builder.Entity<Mensagem>().Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Entity<Mensagem>() // 1 atendimento para N mensagens
                    .HasOne(mensagem => mensagem.Atendimento)
                    .WithMany(atendimento => atendimento.Mensagens)
                    .HasForeignKey(mensagem => mensagem.AtendimentoID)
                    .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region SolveBank
            builder.Entity<SolveBankModel>()
                .HasKey(sb => sb.Id);
            builder.Entity<SolveBankModel>()
                .Property(sb => sb.Id)
                .ValueGeneratedOnAdd();
            #endregion

            #region Pagamentos
            builder.Entity<TPagamento>()
               .HasBaseType<Transacao>();
            #endregion

            #region Pix

            // TODO: EM ABERTO....

            #endregion

            #region Transacoes

            builder.Entity<Transacao>().HasKey(t => t.Id);
            builder.Entity<Transacao>().Property(t => t.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Transacao>()
               .Property(t => t.Valor)
               .HasPrecision(18, 2);
            builder.Entity<Transacao>()
                    .HasOne(t => t.ContaBancaria)
                    .WithMany(cb => cb.Transacoes)
                    .HasForeignKey(conta => conta.ContaID)
                    .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region TransacoesCartoes

            builder.Entity<TransacaoCartao>().HasKey(tc => tc.Id);
            builder.Entity<TransacaoCartao>().Property(tc => tc.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<TransacaoCartao>()
                    .HasOne(cartao => cartao.Cartao)
                    .WithMany(cartao => cartao.TransacoesCartao)
                    .HasForeignKey(cartao => cartao.CartaoID)
                    .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<TransacaoCartao>()
                   .HasOne(t => t.Transacao)
                   .WithMany()
                   .HasForeignKey(t => t.TransacaoID);
            #endregion

            #region Tranferencias
            builder.Entity<TTransferencia>()
                .HasBaseType<Transacao>();
            #endregion

            #region Saques
            builder.Entity<TSaque>()
                .HasBaseType<Transacao>();
            #endregion

            #region Usuario
            builder.Entity<Usuario>()
                .HasIndex(u => u.CPF_CNPJ).IsUnique();
            #endregion

            #region WebToken
            builder.Entity<WebToken>()
                .HasKey(wt => wt.Id);
            builder.Entity<WebToken>()
                .Property(wt => wt.Id).ValueGeneratedOnAdd();
            builder.Entity<WebToken>()
                    .HasOne(wt => wt.Usuario)
                    .WithMany()
                    .HasForeignKey(u => u.UsuarioID)
                    .IsRequired();
            #endregion

            base.OnModelCreating(builder);
        }
    }
}
