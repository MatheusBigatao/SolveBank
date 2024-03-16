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
        public DbSet<Autenticacao2Fatores> Autenticacao2Fatores { get; set; }        
        public DbSet<Cartao> Cartoes { get; set; }        
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; } 
        public DbSet<SolveBankModel> SolveBank { get; set; } 
        public DbSet<TDeposito> Depositos { get; set; } 
        public DbSet<TPagamento> Pagamentos { get; set; } 
        // public DbSet<TPix> Pixs { get; set; }  // --> TODO: Não será implementado por enquanto
        public DbSet<Transacao> Transacoes { get; set; } 
        public DbSet<TransacaoCartao> TransacoesCartoes { get; set; } 
        public DbSet<TTransferencia> Transferencias { get; set; } 
        public DbSet<Usuario> Usuarios { get; set; }        
        public DbSet<WebToken> WebTokens { get; set; }        

        protected override void OnModelCreating(ModelBuilder builder)
        {
        // Seguindo em ordem alfabética da pasta Models
        #region Atendimentos

            builder.Entity<Atendimento>().HasKey(a => a.Id);
            builder.Entity<Atendimento>().Property(a => a.Id).ValueGeneratedOnAdd();
            
            builder.Entity<Atendimento>() // N atendimentos para 1 contaBancaria
                    .HasOne(atendimento => atendimento.ContaBancaria)
                    .WithMany(conta => conta.Atendimentos)
                    .HasForeignKey(a => a.ContaID)
                    .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Atendimento>().Property(a => a.DataSolicitacao).IsRequired();
            builder.Entity<Atendimento>().Property(a => a.DataUltimaResposta);
            builder.Entity<Atendimento>().Property(a => a.StatusAtendimento).IsRequired(); 
        #endregion

        #region Autenticacao2Fatores

            builder.Entity<Autenticacao2Fatores>().HasKey(a => a.Id);
            builder.Entity<Autenticacao2Fatores>().Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Entity<Autenticacao2Fatores>().Property(a => a.Token).IsRequired();
            builder.Entity<Autenticacao2Fatores>().Property(a => a.DataExpiracao) .IsRequired();

            builder.Entity<Autenticacao2Fatores>() // 1 usuario para 1 autenticacao2Fatores
                .HasOne(a => a.Usuario)
                .WithOne()
                .HasForeignKey<Usuario>(usuario => usuario.Id);

            builder.Entity<Autenticacao2Fatores>().Property(a => a.Utilizado).IsRequired();

        #endregion

        #region Cartao

            builder.Entity<Cartao>().HasKey(c => c.Id);
            builder.Entity<Cartao>().Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Entity<Cartao>().Property(c => c.Numero).IsRequired();
            builder.Entity<Cartao>().Property(c => c.Validade).IsRequired();
            builder.Entity<Cartao>().Property(c => c.CVV).IsRequired();

            builder.Entity<Cartao>() // 1 contaBancaria para N cartoes
                .HasOne(c => c.ContaBancaria)
                .WithMany(cb => cb.Cartoes)
                .HasForeignKey(c => c.ContaID);

            builder.Entity<Cartao>().Property(c => c.Limite).IsRequired();
            builder.Entity<Cartao>().Property(c => c.LimiteUtilizado).IsRequired();
            builder.Entity<Cartao>().Property(c => c.EnumTipoCartao).IsRequired();
            builder.Entity<Cartao>().Property(c => c.EnumBandeiraCartao).IsRequired();
            builder.Entity<Cartao>().Property(c => c.EnumCategoriaCartao).IsRequired();
            builder.Entity<Cartao>().HasMany(c => c.TransacoesCartao).WithOne(tc => tc.Cartao).HasForeignKey(tc => tc.Id);
        #endregion

        #region ContasBancarias

            builder.Entity<ContaBancaria>().HasKey(cb => cb.Id);
            builder.Entity<ContaBancaria>().Property(cb => cb.Id).ValueGeneratedOnAdd();

            builder.Entity<ContaBancaria>().Property(cb => cb.Agencia).IsRequired();
            builder.Entity<ContaBancaria>().Property(cb => cb.Numero).IsRequired();
            builder.Entity<ContaBancaria>().Property(cb => cb.Saldo).IsRequired();
            builder.Entity<ContaBancaria>().Property(cb => cb.Limite).IsRequired();

            builder.Entity<ContaBancaria>() // 1 contaBancaria para N transacoes
                .HasMany(cb => cb.Transacoes)
                .WithOne(t => t.ContaBancaria)
                .HasForeignKey(t => t.Id);

            builder.Entity<ContaBancaria>() // N contaBancarias para 1 usuario
                .HasOne(cb => cb.Usuario)
                .WithMany(u => u.ContasBancarias)
                .HasForeignKey(cb => cb.UsuarioID)
                .IsRequired();

            builder.Entity<ContaBancaria>() // 1 contaBancaria para N cartoes
                .HasMany(cb => cb.Cartoes)
                .WithOne(c => c.ContaBancaria);
            
            builder.Entity<ContaBancaria>() // 1 contaBancaria para N atendimentos
                .HasMany(cb => cb.Atendimentos)
                .WithOne(a => a.ContaBancaria)
                .HasForeignKey(a => a.Id);
            
            builder.Entity<ContaBancaria>().Property(cb => cb.EnumCategoriaConta).IsRequired();
            builder.Entity<ContaBancaria>().Property(cb => cb.Informacoes).IsRequired();

        #endregion

        #region Enderecos

            builder.Entity<Endereco>().HasKey(e => e.Id);
            builder.Entity<Endereco>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Endereco>().Property(e => e.UsuarioID).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Logradouro).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Cidade).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Numero).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Bairro).IsRequired();
            builder.Entity<Endereco>().Property(e => e.CEP).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Estado).IsRequired();
            builder.Entity<Endereco>().Property(e => e.Complemento);
            builder.Entity<Endereco>() // 1 usuario para 1 endereco
                .HasOne(e => e.Usuario)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.Id)
                .IsRequired();

        #endregion

        #region Mensagens
            builder.Entity<Mensagem>().HasKey(m => m.Id);
            builder.Entity<Mensagem>().Property(m => m.Id).ValueGeneratedOnAdd();

            builder.Entity<Mensagem>().Property(m => m.ContaID).IsRequired(); 
            builder.Entity<Mensagem>().Property(m => m.AtendimentoID).IsRequired(); 

            builder.Entity<Mensagem>() // 1 atendimento para N mensagens
                    .HasOne(mensagem => mensagem.Atendimento)
                    .WithMany(atendimento => atendimento.Mensagens)
                    .HasForeignKey(mensagem => mensagem.AtendimentoID)
                    .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Mensagem>().Property(m => m.Data).IsRequired();
            builder.Entity<Mensagem>().Property(m => m.Conteudo).IsRequired();
        #endregion

        #region SolveBank

            builder.Entity<SolveBankModel>().HasKey(sb => sb.Id);
            builder.Entity<SolveBankModel>().Property(sb => sb.Id).ValueGeneratedOnAdd();
            builder.Entity<SolveBankModel>().Property(sb => sb.CodigoDoBanco).IsRequired();
        #endregion

        #region Depositos
            builder.Entity<TDeposito>()
                .HasOne(d => d.Transacao)
                .WithOne()
                .HasForeignKey<Transacao>(t => t.Id)
                .IsRequired();

            builder.Entity<TDeposito>().Property(d => d.Agencia).IsRequired();
            builder.Entity<TDeposito>().Property(d => d.NumeroDaConta).IsRequired();
            builder.Entity<TDeposito>().Property(d => d.CodigoDoEnvelope).IsRequired();
        #endregion

        #region Pagamentos
            builder.Entity<TPagamento>()
                .HasOne(p => p.Transacao)
                .WithOne()
                .HasForeignKey<Transacao>(t => t.Id)
                .IsRequired();
            
            builder.Entity<TPagamento>().Property(p => p.Beneficiario).IsRequired();
            builder.Entity<TPagamento>().Property(p => p.NumeroBoleto).IsRequired();

        #endregion

        #region Pix
           
           // TODO: EM ABERTO....

        #endregion

        #region Transacoes

            builder.Entity<Transacao>().HasKey(t => t.Id);
            builder.Entity<Transacao>().Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Entity<Transacao>() // 1 transação para 1 conta
                    .HasOne(t => t.ContaBancaria)
                    .WithOne()
                    .HasForeignKey<ContaBancaria>(conta => conta.Id);
            
            builder.Entity<Transacao>() // 1 conta para N transacoes
                .HasOne(t => t.ContaBancaria) // 1 transação para 1 conta
                .WithMany(c => c.Transacoes) // 1 conta para N transações
                .HasForeignKey(t => t.ContaID) // Chave estrangeira na tabela Transacao
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Transacao>().Property(t => t.CodigoDoBanco) .IsRequired(); 
            builder.Entity<Transacao>().Property(t => t.Valor).IsRequired(); 
            builder.Entity<Transacao>().Property(t => t.DataTransacao).IsRequired(); 
        #endregion
            
        #region TransacoesCartoes

            builder.Entity<TransacaoCartao>() // 1 transação para 1 cartão
                    .HasOne(tc => tc.Transacao)
                    .WithOne()
                    .HasForeignKey<Transacao>(t => t.Id)
                    .IsRequired();

            builder.Entity<TransacaoCartao>() // 1 cartão para 1 transação
                    .HasOne(tc => tc.Cartao)
                    .WithOne()
                    .HasForeignKey<Cartao>(c => c.Id)
                    .IsRequired();
        #endregion

        #region Tranferencias
            builder.Entity<TTransferencia>() // 1 transação para 1 transferencia
                .HasOne(p => p.Transacao)
                .WithOne()
                .HasForeignKey<Transacao>(t => t.Id)
                .IsRequired();
            
            builder.Entity<TTransferencia>().Property(p => p.Beneficiario).IsRequired();
            builder.Entity<TTransferencia>().Property(p => p.AgenciaDestino).IsRequired();
            builder.Entity<TTransferencia>().Property(p => p.NumeroContaDestino).IsRequired();
            builder.Entity<TTransferencia>().Property(p => p.ContaOrigem).IsRequired();

        #endregion

        #region Usuarios
            builder.Entity<Usuario>().HasKey(u => u.Id);
            builder.Entity<Usuario>().Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Entity<Usuario>().Property(u => u.NomeCompleto).IsRequired();
            builder.Entity<Usuario>().Property(u => u.CPF_CNPJ).IsRequired();
            builder.Entity<Usuario>().OwnsOne(u => u.Endereco);
            builder.Entity<Usuario>().Property(u => u.EnumTipoUsuario).IsRequired();
            builder.Entity<Usuario>() // 1 usuario para N contas bancarias
                .HasMany(u => u.ContasBancarias)
                .WithOne(conta => conta.Usuario)
                .HasForeignKey(conta => conta.UsuarioID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Usuario>().Property(u => u.DataCadastro).IsRequired();
            builder.Entity<Usuario>().Property(u => u.Removido).IsRequired();
        #endregion

        #region WebToken
            builder.Entity<WebToken>().HasKey(wt => wt.Id);
            builder.Entity<WebToken>().Property(wt => wt.Id).ValueGeneratedOnAdd();

            builder.Entity<WebToken>() // 1 usuario para 1 webtoken
                    .HasOne(wt => wt.Usuario)
                    .WithOne()
                    .HasForeignKey<Usuario>(u => u.Id)
                    .IsRequired();

            builder.Entity<WebToken>().Property(wt => wt.DataCriado).IsRequired();
            builder.Entity<WebToken>().Property(wt => wt.Utilizado).IsRequired();
            builder.Entity<WebToken>().Property(wt => wt.ExpiracaoToken).IsRequired();

        #endregion

        }
    }
}
