using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarucciHotel.Migrations
{
    /// <inheritdoc />
    public partial class Prenotazione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotazione",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInizioSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFineSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acconto = table.Column<double>(type: "float", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    IDClienteID = table.Column<int>(type: "int", nullable: false),
                    IDCameraID = table.Column<int>(type: "int", nullable: false),
                    IDPensioneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazione", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Camera_IDCameraID",
                        column: x => x.IDCameraID,
                        principalTable: "Camera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Clienti_IDClienteID",
                        column: x => x.IDClienteID,
                        principalTable: "Clienti",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazione_Pensione_IDPensioneID",
                        column: x => x.IDPensioneID,
                        principalTable: "Pensione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IDCameraID",
                table: "Prenotazione",
                column: "IDCameraID");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IDClienteID",
                table: "Prenotazione",
                column: "IDClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazione_IDPensioneID",
                table: "Prenotazione",
                column: "IDPensioneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazione");
        }
    }
}
