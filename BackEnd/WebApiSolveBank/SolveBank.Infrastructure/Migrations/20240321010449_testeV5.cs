using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testeV5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LimiteUtilizado",
                table: "ContasBancarias",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimiteUtilizado",
                table: "ContasBancarias");
        }
    }
}
