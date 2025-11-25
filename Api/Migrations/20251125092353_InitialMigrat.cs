using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aule",
                columns: table => new
                {
                    AulaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capienza = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aule", x => x.AulaId);
                });

            migrationBuilder.CreateTable(
                name: "Classi",
                columns: table => new
                {
                    ClasseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anno = table.Column<int>(type: "int", nullable: false),
                    Sezione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classi", x => x.ClasseId);
                });

            migrationBuilder.CreateTable(
                name: "Corsi",
                columns: table => new
                {
                    CorsoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCorso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Crediti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corsi", x => x.CorsoId);
                });

            migrationBuilder.CreateTable(
                name: "Docenti",
                columns: table => new
                {
                    DocenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenti", x => x.DocenteId);
                });

            migrationBuilder.CreateTable(
                name: "Studenti",
                columns: table => new
                {
                    StudenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenti", x => x.StudenteId);
                });

            migrationBuilder.CreateTable(
                name: "Lezioni",
                columns: table => new
                {
                    LezioneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorsoId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    AulaId = table.Column<int>(type: "int", nullable: false),
                    Inizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Argomento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezioni", x => x.LezioneId);
                    table.ForeignKey(
                        name: "FK_Lezioni_Aule_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aule",
                        principalColumn: "AulaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lezioni_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "CorsoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lezioni_Docenti_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docenti",
                        principalColumn: "DocenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Valutazioni",
                columns: table => new
                {
                    ValutazioneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorsoId = table.Column<int>(type: "int", nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunteggioMassimo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valutazioni", x => x.ValutazioneId);
                    table.ForeignKey(
                        name: "FK_Valutazioni_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "CorsoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Valutazioni_Docenti_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docenti",
                        principalColumn: "DocenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iscrizioni",
                columns: table => new
                {
                    IscrizioneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudenteId = table.Column<int>(type: "int", nullable: false),
                    CorsoId = table.Column<int>(type: "int", nullable: false),
                    ClasseId = table.Column<int>(type: "int", nullable: false),
                    AnnoAccademico = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iscrizioni", x => x.IscrizioneId);
                    table.ForeignKey(
                        name: "FK_Iscrizioni_Classi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Classi",
                        principalColumn: "ClasseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Iscrizioni_Corsi_CorsoId",
                        column: x => x.CorsoId,
                        principalTable: "Corsi",
                        principalColumn: "CorsoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Iscrizioni_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "StudenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presenze",
                columns: table => new
                {
                    PresenzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudenteId = table.Column<int>(type: "int", nullable: false),
                    LezioneId = table.Column<int>(type: "int", nullable: false),
                    Stato = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenze", x => x.PresenzaId);
                    table.ForeignKey(
                        name: "FK_Presenze_Lezioni_LezioneId",
                        column: x => x.LezioneId,
                        principalTable: "Lezioni",
                        principalColumn: "LezioneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenze_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "StudenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voti",
                columns: table => new
                {
                    VotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudenteId = table.Column<int>(type: "int", nullable: false),
                    ValutazioneId = table.Column<int>(type: "int", nullable: false),
                    Punteggio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Commento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voti", x => x.VotoId);
                    table.ForeignKey(
                        name: "FK_Voti_Studenti_StudenteId",
                        column: x => x.StudenteId,
                        principalTable: "Studenti",
                        principalColumn: "StudenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voti_Valutazioni_ValutazioneId",
                        column: x => x.ValutazioneId,
                        principalTable: "Valutazioni",
                        principalColumn: "ValutazioneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Iscrizioni_CorsoId",
                table: "Iscrizioni",
                column: "CorsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Iscrizioni_StudenteId_CorsoId_AnnoAccademico",
                table: "Iscrizioni",
                columns: new[] { "StudenteId", "CorsoId", "AnnoAccademico" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_AulaId",
                table: "Lezioni",
                column: "AulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_CorsoId",
                table: "Lezioni",
                column: "CorsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lezioni_DocenteId",
                table: "Lezioni",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Presenze_LezioneId",
                table: "Presenze",
                column: "LezioneId");

            migrationBuilder.CreateIndex(
                name: "IX_Presenze_StudenteId",
                table: "Presenze",
                column: "StudenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Valutazioni_CorsoId",
                table: "Valutazioni",
                column: "CorsoId");

            migrationBuilder.CreateIndex(
                name: "IX_Valutazioni_DocenteId",
                table: "Valutazioni",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Voti_StudenteId",
                table: "Voti",
                column: "StudenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Voti_ValutazioneId",
                table: "Voti",
                column: "ValutazioneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Iscrizioni");

            migrationBuilder.DropTable(
                name: "Presenze");

            migrationBuilder.DropTable(
                name: "Voti");

            migrationBuilder.DropTable(
                name: "Classi");

            migrationBuilder.DropTable(
                name: "Lezioni");

            migrationBuilder.DropTable(
                name: "Studenti");

            migrationBuilder.DropTable(
                name: "Valutazioni");

            migrationBuilder.DropTable(
                name: "Aule");

            migrationBuilder.DropTable(
                name: "Corsi");

            migrationBuilder.DropTable(
                name: "Docenti");
        }
    }
}
