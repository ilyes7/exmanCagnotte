using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fisrtmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entreprises",
                columns: table => new
                {
                    EntrepriseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresseEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomEntreprise = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprises", x => x.EntrepriseId);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MailParticipant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "Cagnottes",
                columns: table => new
                {
                    CagnotteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SommeDemendee = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    EntrepriseFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cagnottes", x => x.CagnotteId);
                    table.ForeignKey(
                        name: "FK_Cagnottes_Entreprises_EntrepriseFk",
                        column: x => x.EntrepriseFk,
                        principalTable: "Entreprises",
                        principalColumn: "EntrepriseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CagnotteParticipant",
                columns: table => new
                {
                    CagnottesCagnotteId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CagnotteParticipant", x => new { x.CagnottesCagnotteId, x.ParticipantsParticipantId });
                    table.ForeignKey(
                        name: "FK_CagnotteParticipant_Cagnottes_CagnottesCagnotteId",
                        column: x => x.CagnottesCagnotteId,
                        principalTable: "Cagnottes",
                        principalColumn: "CagnotteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CagnotteParticipant_Participants_ParticipantsParticipantId",
                        column: x => x.ParticipantsParticipantId,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    CagnotteFk = table.Column<int>(type: "int", nullable: false),
                    ParticipantFk = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => new { x.CagnotteFk, x.ParticipantFk });
                    table.ForeignKey(
                        name: "FK_Participations_Cagnottes_CagnotteFk",
                        column: x => x.CagnotteFk,
                        principalTable: "Cagnottes",
                        principalColumn: "CagnotteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_Participants_ParticipantFk",
                        column: x => x.ParticipantFk,
                        principalTable: "Participants",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CagnotteParticipant_ParticipantsParticipantId",
                table: "CagnotteParticipant",
                column: "ParticipantsParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_Cagnottes_EntrepriseFk",
                table: "Cagnottes",
                column: "EntrepriseFk");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_ParticipantFk",
                table: "Participations",
                column: "ParticipantFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CagnotteParticipant");

            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "Cagnottes");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Entreprises");
        }
    }
}
