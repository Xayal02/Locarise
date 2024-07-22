using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class AddContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact_us_requests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requester_full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requester_email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requester_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    request_message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    request_date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 24, 13, 57, 5, 440, DateTimeKind.Utc).AddTicks(9257))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_us_requests", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contact_us_requests");
        }
    }
}
