using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class DeleteTitleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tittle",
                table: "comments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "services",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "comments",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "services",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "comments",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "tittle",
                table: "comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
