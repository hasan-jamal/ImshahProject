using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImshahProject.Web.Data.Migrations
{
    public partial class add_hasanAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "a10a8fb5-b8c6-4885-9b1f-3ac786b7e8bc", "hasanjamal@imashah.com", "Hasan", "hasanjamal@imashah.com", "hasanJamal", "AQAAAAEAACcQAAAAECv8RnU6gMuieXjISkPx0ml5HJxxq3cwvkkHZmnEkXoyNTEaVMY2Pu15YKPm3lC/bQ==", "hasanJamal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
