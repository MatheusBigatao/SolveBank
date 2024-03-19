using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolveBank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testeV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ContasBancarias_Numero",
                table: "ContasBancarias",
                column: "Numero",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContasBancarias_Numero",
                table: "ContasBancarias");
        }
    }
}
