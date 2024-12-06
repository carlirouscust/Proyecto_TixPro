using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_TixPro.Data.Migrations
{
    /// <inheritdoc />
    public partial class agregarcarrusel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrusel",
                columns: table => new
                {
                    carruselId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen5 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrusel", x => x.carruselId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrusel");
        }
    }
}
