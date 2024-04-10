using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class AddDataToRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "deleted_date", "is_deleted", "name" },
                values: new object[] { 1, null, false, "Admin" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "deleted_date", "is_deleted", "name" },
                values: new object[] { 2, null, false, "Freelancer" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "deleted_date", "is_deleted", "name" },
                values: new object[] { 3, null, false, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
