using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class AddTeamMembersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 8, 53, 3, 402, DateTimeKind.Utc).AddTicks(671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 24, 13, 57, 5, 440, DateTimeKind.Utc).AddTicks(9257));

            migrationBuilder.CreateTable(
                name: "team_members",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_user_id = table.Column<short>(type: "smallint", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_user_id = table.Column<short>(type: "smallint", nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_team_members", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "team_members");

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 24, 13, 57, 5, 440, DateTimeKind.Utc).AddTicks(9257),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 8, 53, 3, 402, DateTimeKind.Utc).AddTicks(671));
        }
    }
}
