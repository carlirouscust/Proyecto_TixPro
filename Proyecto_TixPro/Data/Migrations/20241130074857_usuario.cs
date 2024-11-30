using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_TixPro.Data.Migrations
{
    /// <inheritdoc />
    public partial class usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "asunto",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "comentario",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    tarjetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaExpiracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigoSeguridad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.tarjetaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropColumn(
                name: "asunto",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "comentario",
                table: "Usuario");
        }
    }
}
