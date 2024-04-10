using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class AddClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Fields",
                table: "Fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FAQs",
                table: "FAQs");

            migrationBuilder.RenameTable(
                name: "Fields",
                newName: "fields");

            migrationBuilder.RenameTable(
                name: "FAQs",
                newName: "faqs");

            migrationBuilder.RenameColumn(
                name: "IconPath",
                table: "services",
                newName: "icon_path");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "fields",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fields",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "fields",
                newName: "updated_user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "fields",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "fields",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "fields",
                newName: "created_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "fields",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Tittle",
                table: "faqs",
                newName: "tittle");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "faqs",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "faqs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedUserId",
                table: "faqs",
                newName: "updated_user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "faqs",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "faqs",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                table: "faqs",
                newName: "created_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "faqs",
                newName: "created_date");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "fields",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "faqs",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fields",
                table: "fields",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_faqs",
                table: "faqs",
                column: "id");

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_user_id = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_user_id = table.Column<long>(type: "bigint", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fields",
                table: "fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_faqs",
                table: "faqs");

            migrationBuilder.RenameTable(
                name: "fields",
                newName: "Fields");

            migrationBuilder.RenameTable(
                name: "faqs",
                newName: "FAQs");

            migrationBuilder.RenameColumn(
                name: "icon_path",
                table: "services",
                newName: "IconPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Fields",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Fields",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_user_id",
                table: "Fields",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Fields",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "Fields",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_user_id",
                table: "Fields",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Fields",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "tittle",
                table: "FAQs",
                newName: "Tittle");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "FAQs",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "FAQs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_user_id",
                table: "FAQs",
                newName: "UpdatedUserId");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "FAQs",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "FAQs",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "created_user_id",
                table: "FAQs",
                newName: "CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "FAQs",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Fields",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "FAQs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fields",
                table: "Fields",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FAQs",
                table: "FAQs",
                column: "Id");
        }
    }
}
