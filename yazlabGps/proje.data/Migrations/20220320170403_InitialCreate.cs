using Microsoft.EntityFrameworkCore.Migrations;

namespace proje.data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arabas",
                columns: table => new
                {
                    ArabaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isim = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arabas", x => x.ArabaId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isim = table.Column<string>(type: "TEXT", nullable: true),
                    soyisim = table.Column<string>(type: "TEXT", nullable: true),
                    kullaniciAdi = table.Column<string>(type: "TEXT", nullable: true),
                    TelNo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciArabalaris",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArabaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciArabalaris", x => new { x.ArabaId, x.KullaniciId });
                    table.ForeignKey(
                        name: "FK_KullaniciArabalaris_Arabas_ArabaId",
                        column: x => x.ArabaId,
                        principalTable: "Arabas",
                        principalColumn: "ArabaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciArabalaris_Kullanicis_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciArabalaris_KullaniciId",
                table: "KullaniciArabalaris",
                column: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KullaniciArabalaris");

            migrationBuilder.DropTable(
                name: "Arabas");

            migrationBuilder.DropTable(
                name: "Kullanicis");
        }
    }
}
