using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_TixPro.Data.Migrations
{
    /// <inheritdoc />
    public partial class generarticket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "codigosTickets",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigosTickets",
                table: "Ticket");
        }
    }
}
