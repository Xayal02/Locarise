using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class ChangedTheColumnCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "users",
                newName: "full_name");

            migrationBuilder.RenameColumn(
                name: "EmailConfirmed",
                table: "users",
                newName: "email_confirmed");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "users",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "UpdatedTime",
                table: "users",
                newName: "updated_date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "full_name",
                table: "users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "email_confirmed",
                table: "users",
                newName: "EmailConfirmed");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "users",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "users",
                newName: "UpdatedTime");
        }
    }
}
