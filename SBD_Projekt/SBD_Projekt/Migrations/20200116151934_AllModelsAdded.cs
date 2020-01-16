using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD_Projekt.Migrations
{
    public partial class AllModelsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    id_adres = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kraj = table.Column<string>(nullable: true),
                    Miasto = table.Column<string>(nullable: true),
                    Województwo = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    Nr_domu = table.Column<string>(nullable: true),
                    Nr_miszkania = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.id_adres);
                });

            migrationBuilder.CreateTable(
                name: "Budynek",
                columns: table => new
                {
                    id_budynek = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miasto = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true),
                    KodPocztowy = table.Column<string>(nullable: true),
                    NrBudynku = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budynek", x => x.id_budynek);
                });

            migrationBuilder.CreateTable(
                name: "Dowod",
                columns: table => new
                {
                    id_dowod = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true),
                    Typ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dowod", x => x.id_dowod);
                });

            migrationBuilder.CreateTable(
                name: "Godziny",
                columns: table => new
                {
                    id_godziny = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdGodziny = table.Column<DateTime>(nullable: false),
                    DoGodziny = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Godziny", x => x.id_godziny);
                });

            migrationBuilder.CreateTable(
                name: "Klient",
                columns: table => new
                {
                    id_klient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_osoba = table.Column<int>(nullable: false),
                    id_prawnik = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klient", x => x.id_klient);
                });

            migrationBuilder.CreateTable(
                name: "Obsluga",
                columns: table => new
                {
                    id_obsluga = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_osoba = table.Column<int>(nullable: false),
                    id_zarobki = table.Column<int>(nullable: false),
                    id_godziny = table.Column<int>(nullable: false),
                    typ = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obsluga", x => x.id_obsluga);
                });

            migrationBuilder.CreateTable(
                name: "Prawnik",
                columns: table => new
                {
                    id_prawnik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_osoba = table.Column<int>(nullable: false),
                    id_godziny = table.Column<int>(nullable: false),
                    id_zarobki = table.Column<int>(nullable: false),
                    id_specjalizacja = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prawnik", x => x.id_prawnik);
                });

            migrationBuilder.CreateTable(
                name: "Rozprawa",
                columns: table => new
                {
                    id_rozprawa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_godziny = table.Column<int>(nullable: false),
                    id_wydzial = table.Column<int>(nullable: false),
                    id_dowod = table.Column<int>(nullable: false),
                    id_sedzia = table.Column<int>(nullable: false),
                    id_prawnik = table.Column<int>(nullable: false),
                    id_klient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rozprawa", x => x.id_rozprawa);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    id_sala = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rodzaj = table.Column<string>(nullable: true),
                    Wielkosc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.id_sala);
                });

            migrationBuilder.CreateTable(
                name: "Sedzia",
                columns: table => new
                {
                    id_sedzia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_osoba = table.Column<int>(nullable: false),
                    id_wydzial = table.Column<int>(nullable: false),
                    id_zarobki = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedzia", x => x.id_sedzia);
                });

            migrationBuilder.CreateTable(
                name: "Specjalizacja",
                columns: table => new
                {
                    id_specjalizacja = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwa = table.Column<string>(nullable: true),
                    doswiadczenie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specjalizacja", x => x.id_specjalizacja);
                });

            migrationBuilder.CreateTable(
                name: "Spotkanie",
                columns: table => new
                {
                    id_spotkanie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_sali = table.Column<int>(nullable: false),
                    id_godziny = table.Column<int>(nullable: false),
                    id_prawnik = table.Column<int>(nullable: false),
                    id_klient = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spotkanie", x => x.id_spotkanie);
                });

            migrationBuilder.CreateTable(
                name: "Wydzial",
                columns: table => new
                {
                    id_wydzial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_budynku = table.Column<int>(nullable: false),
                    nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydzial", x => x.id_wydzial);
                });

            migrationBuilder.CreateTable(
                name: "Zarobki",
                columns: table => new
                {
                    id_zarobki = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zarobek = table.Column<float>(nullable: false),
                    premia = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zarobki", x => x.id_zarobki);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Budynek");

            migrationBuilder.DropTable(
                name: "Dowod");

            migrationBuilder.DropTable(
                name: "Godziny");

            migrationBuilder.DropTable(
                name: "Klient");

            migrationBuilder.DropTable(
                name: "Obsluga");

            migrationBuilder.DropTable(
                name: "Prawnik");

            migrationBuilder.DropTable(
                name: "Rozprawa");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Sedzia");

            migrationBuilder.DropTable(
                name: "Specjalizacja");

            migrationBuilder.DropTable(
                name: "Spotkanie");

            migrationBuilder.DropTable(
                name: "Wydzial");

            migrationBuilder.DropTable(
                name: "Zarobki");
        }
    }
}
