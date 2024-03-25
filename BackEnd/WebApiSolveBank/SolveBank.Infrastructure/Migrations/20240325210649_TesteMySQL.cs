using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SolveBank.Infrastructure.Migrations
{
    public partial class TesteMySQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SolveBank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CodigoDoBanco = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolveBank", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "longtext", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(255)", nullable: false),
                    EnumTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Removido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SolveBankModelId = table.Column<Guid>(type: "char(36)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_SolveBank_SolveBankModelId",
                        column: x => x.SolveBankModelId,
                        principalTable: "SolveBank",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Autenticacao2Fatores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false),
                    DataExpiracao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioID = table.Column<string>(type: "varchar(255)", nullable: false),
                    Utilizado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autenticacao2Fatores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autenticacao2Fatores_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContasBancarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Agencia = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<int>(type: "int", fixedLength: true, maxLength: 8, nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LimiteUtilizado = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UsuarioID = table.Column<string>(type: "varchar(255)", nullable: false),
                    EnumCategoriaConta = table.Column<int>(type: "int", nullable: false),
                    Informacoes = table.Column<string>(type: "longtext", nullable: false),
                    Removido = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasBancarias", x => x.Id);
                    table.UniqueConstraint("AK_ContasBancarias_Numero", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_ContasBancarias_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    UsuarioId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Logradouro = table.Column<string>(type: "longtext", nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<string>(type: "longtext", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: false),
                    CEP = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false),
                    Complemento = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WebTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false),
                    UsuarioID = table.Column<string>(type: "varchar(255)", nullable: false),
                    DataCriado = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpiracaoToken = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebTokens_AspNetUsers_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContaID = table.Column<Guid>(type: "char(36)", nullable: false),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataUltimaResposta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusAtendimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_ContasBancarias_ContaID",
                        column: x => x.ContaID,
                        principalTable: "ContasBancarias",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Numero = table.Column<string>(type: "longtext", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CVV = table.Column<string>(type: "longtext", nullable: false),
                    ContaID = table.Column<Guid>(type: "char(36)", nullable: false),
                    Limite = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LimiteUtilizado = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EnumTipoCartao = table.Column<int>(type: "int", nullable: false),
                    EnumBandeiraCartao = table.Column<int>(type: "int", nullable: false),
                    EnumCategoriaCartao = table.Column<int>(type: "int", nullable: false),
                    ContaBancariaId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartoes_ContasBancarias_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalTable: "ContasBancarias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cartoes_ContasBancarias_ContaID",
                        column: x => x.ContaID,
                        principalTable: "ContasBancarias",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContaID = table.Column<Guid>(type: "char(36)", nullable: false),
                    CodigoDoBanco = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataTransacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false),
                    Agencia = table.Column<string>(type: "longtext", nullable: true),
                    NumeroDaConta = table.Column<long>(type: "bigint", nullable: true),
                    CodigoDoEnvelope = table.Column<string>(type: "longtext", nullable: true),
                    TPagamento_Beneficiario = table.Column<string>(type: "longtext", nullable: true),
                    NumeroBoleto = table.Column<string>(type: "longtext", nullable: true),
                    LocalDoSaque = table.Column<string>(type: "longtext", nullable: true),
                    Beneficiario = table.Column<string>(type: "longtext", nullable: true),
                    AgenciaDestino = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    NumeroContaDestino = table.Column<long>(type: "bigint", maxLength: 20, nullable: true),
                    ContaOrigem = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_ContasBancarias_ContaID",
                        column: x => x.ContaID,
                        principalTable: "ContasBancarias",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ContaID = table.Column<Guid>(type: "char(36)", nullable: false),
                    AtendimentoID = table.Column<Guid>(type: "char(36)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Conteudo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_Atendimentos_AtendimentoID",
                        column: x => x.AtendimentoID,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransacoesCartoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TransacaoID = table.Column<Guid>(type: "char(36)", nullable: false),
                    CartaoID = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacoesCartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransacoesCartoes_Cartoes_CartaoID",
                        column: x => x.CartaoID,
                        principalTable: "Cartoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransacoesCartoes_Transacoes_TransacaoID",
                        column: x => x.TransacaoID,
                        principalTable: "Transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CPF_CNPJ",
                table: "AspNetUsers",
                column: "CPF_CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SolveBankModelId",
                table: "AspNetUsers",
                column: "SolveBankModelId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ContaID",
                table: "Atendimentos",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_Autenticacao2Fatores_UsuarioID",
                table: "Autenticacao2Fatores",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ContaBancariaId",
                table: "Cartoes",
                column: "ContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cartoes_ContaID",
                table: "Cartoes",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_ContasBancarias_UsuarioID",
                table: "ContasBancarias",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_AtendimentoID",
                table: "Mensagens",
                column: "AtendimentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaID",
                table: "Transacoes",
                column: "ContaID");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesCartoes_CartaoID",
                table: "TransacoesCartoes",
                column: "CartaoID");

            migrationBuilder.CreateIndex(
                name: "IX_TransacoesCartoes_TransacaoID",
                table: "TransacoesCartoes",
                column: "TransacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_WebTokens_UsuarioID",
                table: "WebTokens",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Autenticacao2Fatores");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "TransacoesCartoes");

            migrationBuilder.DropTable(
                name: "WebTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "Transacoes");

            migrationBuilder.DropTable(
                name: "ContasBancarias");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SolveBank");
        }
    }
}
