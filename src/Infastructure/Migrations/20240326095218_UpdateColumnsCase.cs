using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class UpdateColumnsCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "services");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");

            migrationBuilder.RenameColumn(
                name: "Tittle",
                table: "services",
                newName: "tittle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "services",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "services",
                newName: "updated_user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "services",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "services",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "services",
                newName: "created_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "services",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "comments",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Tittle",
                table: "comments",
                newName: "tittle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "comments",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "UserFullName",
                table: "comments",
                newName: "user_full_name");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "comments",
                newName: "updated_user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "comments",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "comments",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "comments",
                newName: "created_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "comments",
                newName: "created_date");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "comments",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_services",
                table: "services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_services",
                table: "services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.RenameTable(
                name: "services",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "tittle",
                table: "Services",
                newName: "Tittle");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Services",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "updated_user_id",
                table: "Services",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Services",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Services",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_user_id",
                table: "Services",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Services",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Comments",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "tittle",
                table: "Comments",
                newName: "Tittle");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Comments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "user_full_name",
                table: "Comments",
                newName: "UserFullName");

            migrationBuilder.RenameColumn(
                name: "updated_user_id",
                table: "Comments",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Comments",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Comments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_user_id",
                table: "Comments",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Comments",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");
        }
    }
}
