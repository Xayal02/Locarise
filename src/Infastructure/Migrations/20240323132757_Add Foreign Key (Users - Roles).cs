using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class AddForeignKeyUsersRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_RoleId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "users");
        }
    }
}
