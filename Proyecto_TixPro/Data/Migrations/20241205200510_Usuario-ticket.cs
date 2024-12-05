using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_TixPro.Data.Migrations
{
    /// <inheritdoc />
    public partial class Usuarioticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_usuarioId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_usuarioId",
                table: "Ticket",
                column: "usuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ticket_usuarioId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_usuarioId",
                table: "Ticket",
                column: "usuarioId");
        }
    }
}
