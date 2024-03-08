using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarucciHotel.Migrations
{
    /// <inheritdoc />
    public partial class servizi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Descrizione",
                table: "Servizi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CheckoutView",
                columns: table => new
                {
                    PrenotazioneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CheckoutView_Prenotazione_PrenotazioneID",
                        column: x => x.PrenotazioneID,
                        principalTable: "Prenotazione",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutView_PrenotazioneID",
                table: "CheckoutView",
                column: "PrenotazioneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutView");

            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Servizi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
