using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEventos.Migrations
{
    /// <inheritdoc />
    public partial class TablaEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEvento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionDelEvento = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    FechaDelEvento = table.Column<DateOnly>(type: "date", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
