using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_TixPro.Data.Migrations
{
    /// <inheritdoc />
    public partial class Resenas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    reviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ratingUso = table.Column<int>(type: "int", nullable: false),
                    cosasMejorar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recomendarias = table.Column<bool>(type: "bit", nullable: false),
                    fechaReview = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.reviewId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
