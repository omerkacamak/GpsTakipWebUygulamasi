using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proje.data.Migrations
{
    public partial class girisCikis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KullaniciCikises",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    cikisZamani = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciCikises", x => x.KullaniciId);
                    table.ForeignKey(
                        name: "FK_KullaniciCikises_Kullanicis_KullaniciId1",
                        column: x => x.KullaniciId1,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciGirises",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId1 = table.Column<int>(type: "INTEGER", nullable: false),
                    girisZamani = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciGirises", x => x.KullaniciId);
                    table.ForeignKey(
                        name: "FK_KullaniciGirises_Kullanicis_KullaniciId1",
                        column: x => x.KullaniciId1,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciCikises_KullaniciId1",
                table: "KullaniciCikises",
                column: "KullaniciId1");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciGirises_KullaniciId1",
                table: "KullaniciGirises",
                column: "KullaniciId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciCikises");

            migrationBuilder.DropTable(
                name: "KullaniciGirises");
        }
    }
}
