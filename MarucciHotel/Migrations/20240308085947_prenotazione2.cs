using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarucciHotel.Migrations
{
    /// <inheritdoc />
    public partial class prenotazione2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Camera_IDCameraID",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Clienti_IDClienteID",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensioneID",
                table: "Prenotazione");

            migrationBuilder.RenameColumn(
                name: "IDPensioneID",
                table: "Prenotazione",
                newName: "IDPensione");

            migrationBuilder.RenameColumn(
                name: "IDClienteID",
                table: "Prenotazione",
                newName: "IDCliente");

            migrationBuilder.RenameColumn(
                name: "IDCameraID",
                table: "Prenotazione",
                newName: "IDCamera");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDPensioneID",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDPensione");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDClienteID",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDCameraID",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDCamera");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Camera_IDCamera",
                table: "Prenotazione",
                column: "IDCamera",
                principalTable: "Camera",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Clienti_IDCliente",
                table: "Prenotazione",
                column: "IDCliente",
                principalTable: "Clienti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensione",
                table: "Prenotazione",
                column: "IDPensione",
                principalTable: "Pensione",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Camera_IDCamera",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Clienti_IDCliente",
                table: "Prenotazione");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensione",
                table: "Prenotazione");

            migrationBuilder.RenameColumn(
                name: "IDPensione",
                table: "Prenotazione",
                newName: "IDPensioneID");

            migrationBuilder.RenameColumn(
                name: "IDCliente",
                table: "Prenotazione",
                newName: "IDClienteID");

            migrationBuilder.RenameColumn(
                name: "IDCamera",
                table: "Prenotazione",
                newName: "IDCameraID");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDPensione",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDPensioneID");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDCliente",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDClienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazione_IDCamera",
                table: "Prenotazione",
                newName: "IX_Prenotazione_IDCameraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Camera_IDCameraID",
                table: "Prenotazione",
                column: "IDCameraID",
                principalTable: "Camera",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Clienti_IDClienteID",
                table: "Prenotazione",
                column: "IDClienteID",
                principalTable: "Clienti",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazione_Pensione_IDPensioneID",
                table: "Prenotazione",
                column: "IDPensioneID",
                principalTable: "Pensione",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
