using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImshahProject.Web.Data.Migrations
{
    public partial class Add_Links_icons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Instgram",
                table: "Informations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tiktok",
                table: "Informations",
                type: "nvarchar(max)",
                nullable: true);

            }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instgram",
                table: "Informations");

            migrationBuilder.DropColumn(
                name: "Tiktok",
                table: "Informations");

            }
    }
}
