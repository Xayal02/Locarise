using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class SLightlyModifyTeamMembersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "team_members",
                newName: "position");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "team_members",
                newName: "is_deleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 9, 3, 33, 862, DateTimeKind.Utc).AddTicks(8084),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 8, 53, 3, 402, DateTimeKind.Utc).AddTicks(671));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "position",
                table: "team_members",
                newName: "Position");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                table: "team_members",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 8, 53, 3, 402, DateTimeKind.Utc).AddTicks(671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 9, 3, 33, 862, DateTimeKind.Utc).AddTicks(8084));
        }
    }
}
