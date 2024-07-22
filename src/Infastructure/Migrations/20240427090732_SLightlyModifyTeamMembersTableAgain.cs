using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class SLightlyModifyTeamMembersTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "team_members",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 9, 7, 32, 22, DateTimeKind.Utc).AddTicks(7577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 9, 3, 33, 862, DateTimeKind.Utc).AddTicks(8084));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "team_members",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 9, 3, 33, 862, DateTimeKind.Utc).AddTicks(8084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 9, 7, 32, 22, DateTimeKind.Utc).AddTicks(7577));
        }
    }
}
