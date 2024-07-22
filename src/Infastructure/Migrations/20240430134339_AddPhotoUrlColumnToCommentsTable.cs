using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class AddPhotoUrlColumnToCommentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 30, 13, 43, 38, 723, DateTimeKind.Utc).AddTicks(9820),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 29, 11, 37, 43, 580, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.AddColumn<string>(
                name: "UserImageUrl",
                table: "comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImageUrl",
                table: "comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 29, 11, 37, 43, 580, DateTimeKind.Utc).AddTicks(9551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 30, 13, 43, 38, 723, DateTimeKind.Utc).AddTicks(9820));
        }
    }
}
