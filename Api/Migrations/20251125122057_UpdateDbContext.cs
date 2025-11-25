using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iscrizioni_Classi_CorsoId",
                table: "Iscrizioni");

            migrationBuilder.CreateIndex(
                name: "IX_Iscrizioni_ClasseId",
                table: "Iscrizioni",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Iscrizioni_Classi_ClasseId",
                table: "Iscrizioni",
                column: "ClasseId",
                principalTable: "Classi",
                principalColumn: "ClasseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Iscrizioni_Classi_ClasseId",
                table: "Iscrizioni");

            migrationBuilder.DropIndex(
                name: "IX_Iscrizioni_ClasseId",
                table: "Iscrizioni");

            migrationBuilder.AddForeignKey(
                name: "FK_Iscrizioni_Classi_CorsoId",
                table: "Iscrizioni",
                column: "CorsoId",
                principalTable: "Classi",
                principalColumn: "ClasseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
