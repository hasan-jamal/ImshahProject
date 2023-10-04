using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImshahProject.Web.Data.Migrations
{
    public partial class add_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5761da7-a17f-48fa-bcd3-aa25d7b75d15",
                column: "ConcurrencyStamp",
                value: "2c319383-7b27-4e33-b189-18f5670254e8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59",
                column: "ConcurrencyStamp",
                value: "5f15af0d-ff9f-4001-82b4-aeabfbe28338");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "72feed20-6917-4951-b42d-f24049d969ee", "admin@imashah.com", "Admin", "admin@imashah.com", "adminNew", "AQAAAAEAACcQAAAAEGR0G8z6hPW7OFWcA4e9uej5Xcf93OWmn5ATM8DadR4QcX5FjpFkUFh/nsGHajej3A==", "adminNew" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5761da7-a17f-48fa-bcd3-aa25d7b75d15",
                column: "ConcurrencyStamp",
                value: "53810a7f-a983-431a-a7bf-3aad19c7fb76");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59",
                column: "ConcurrencyStamp",
                value: "9de0a466-8ee7-4df3-b5c1-6a9dff4087b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "Email", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "a10a8fb5-b8c6-4885-9b1f-3ac786b7e8bc", "hasanjamal@imashah.com", "Hasan", "hasanjamal@imashah.com", "hasanJamal", "AQAAAAEAACcQAAAAECv8RnU6gMuieXjISkPx0ml5HJxxq3cwvkkHZmnEkXoyNTEaVMY2Pu15YKPm3lC/bQ==", "hasanJamal" });
        }
    }
}
