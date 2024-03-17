using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testeV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Utilizado",
                table: "WebTokens");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "ContasBancarias",
                type: "int",
                unicode: false,
                maxLength: 6,
                nullable: false,
                computedColumnSql: "RIGHT('000000' + CAST(NumeroConta AS VARCHAR(6)), 6)",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Utilizado",
                table: "WebTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "ContasBancarias",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false,
                oldMaxLength: 6,
                oldComputedColumnSql: "RIGHT('000000' + CAST(NumeroConta AS VARCHAR(6)), 6)")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
