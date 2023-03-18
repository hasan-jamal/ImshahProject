using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImshahProject.Web.Data.Migrations
{
    public partial class add_ImageUrl_To_Goal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "Goals",
                type: "nvarchar(max)",
                nullable: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "Goals");
        }
    }
}
