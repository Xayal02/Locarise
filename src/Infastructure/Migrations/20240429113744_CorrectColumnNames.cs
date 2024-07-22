using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class CorrectColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tittle",
                table: "services",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "tittle",
                table: "faqs",
                newName: "title");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 11, 37, 43, 580, DateTimeKind.Utc).AddTicks(9551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 20, 56, 21, 884, DateTimeKind.Utc).AddTicks(1509));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "services",
                newName: "tittle");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "faqs",
                newName: "tittle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 20, 56, 21, 884, DateTimeKind.Utc).AddTicks(1509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 11, 37, 43, 580, DateTimeKind.Utc).AddTicks(9551));
        }
    }
}
