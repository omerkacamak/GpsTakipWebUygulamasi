using Microsoft.EntityFrameworkCore.Migrations;

namespace proje.data.Migrations
{
    public partial class sifre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelNo",
                table: "Kullanicis",
                newName: "sifre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sifre",
                table: "Kullanicis",
                newName: "TelNo");
        }
    }
}
