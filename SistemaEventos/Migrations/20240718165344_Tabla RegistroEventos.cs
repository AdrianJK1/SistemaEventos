using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEventos.Migrations
{
    /// <inheritdoc />
    public partial class TablaRegistroEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroEvento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventoID = table.Column<int>(type: "int", nullable: false),
                    ParticipanteID = table.Column<int>(type: "int", nullable: false),
                    FechaDelRegistro = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroEvento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroEvento_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroEvento_Participantes_ParticipanteID",
                        column: x => x.ParticipanteID,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEvento_EventoID",
                table: "RegistroEvento",
                column: "EventoID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroEvento_ParticipanteID",
                table: "RegistroEvento",
                column: "ParticipanteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroEvento");
        }
    }
}
