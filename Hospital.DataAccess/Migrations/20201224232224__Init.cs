using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.DataAccess.Migrations
{
    public partial class _Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doktor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Jmbg = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    Specijalnost = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Jmbg = table.Column<int>(type: "int", maxLength: 13, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipPregleda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipPregleda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raspored",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raspored", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raspored_Doktor_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoktorTipPregleda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    TipPregledaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorTipPregleda", x => new { x.Id, x.DoktorId, x.TipPregledaId });
                    table.ForeignKey(
                        name: "FK_DoktorTipPregleda_Doktor_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoktorTipPregleda_TipPregleda_TipPregledaId",
                        column: x => x.TipPregledaId,
                        principalTable: "TipPregleda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremePocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    RasporedId = table.Column<int>(type: "int", nullable: false),
                    ZakazivanjePregledaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Termin_Raspored_RasporedId",
                        column: x => x.RasporedId,
                        principalTable: "Raspored",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ZakazivanjePregleda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    KlijentId = table.Column<int>(type: "int", nullable: false),
                    TipPregledaId = table.Column<int>(type: "int", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    TerminId = table.Column<int>(type: "int", nullable: false),
                    RasporedId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZakazivanjePregleda", x => new { x.Id, x.KlijentId, x.TipPregledaId });
                    table.ForeignKey(
                        name: "FK_ZakazivanjePregleda_Klijent_KlijentId",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZakazivanjePregleda_Raspored_RasporedId",
                        column: x => x.RasporedId,
                        principalTable: "Raspored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZakazivanjePregleda_Termin_TerminId",
                        column: x => x.TerminId,
                        principalTable: "Termin",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ZakazivanjePregleda_TipPregleda_TipPregledaId",
                        column: x => x.TipPregledaId,
                        principalTable: "TipPregleda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoktorTipPregleda_DoktorId",
                table: "DoktorTipPregleda",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoktorTipPregleda_TipPregledaId",
                table: "DoktorTipPregleda",
                column: "TipPregledaId");

            migrationBuilder.CreateIndex(
                name: "IX_Raspored_DoktorId",
                table: "Raspored",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_RasporedId",
                table: "Termin",
                column: "RasporedId");

            migrationBuilder.CreateIndex(
                name: "IX_ZakazivanjePregleda_KlijentId",
                table: "ZakazivanjePregleda",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_ZakazivanjePregleda_RasporedId",
                table: "ZakazivanjePregleda",
                column: "RasporedId");

            migrationBuilder.CreateIndex(
                name: "IX_ZakazivanjePregleda_TerminId",
                table: "ZakazivanjePregleda",
                column: "TerminId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZakazivanjePregleda_TipPregledaId",
                table: "ZakazivanjePregleda",
                column: "TipPregledaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoktorTipPregleda");

            migrationBuilder.DropTable(
                name: "ZakazivanjePregleda");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "TipPregleda");

            migrationBuilder.DropTable(
                name: "Raspored");

            migrationBuilder.DropTable(
                name: "Doktor");
        }
    }
}
