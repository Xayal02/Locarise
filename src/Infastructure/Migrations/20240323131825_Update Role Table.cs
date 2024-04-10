using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class UpdateRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "roles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "roles",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "roles",
                newName: "deleted_date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Roles",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "Roles",
                newName: "DeletedDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");
        }
    }
}
