using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infastructure.Migrations
{
    public partial class ChangeTheTypesOfCreatedUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_date",
                table: "roles");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "team_members",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<short>(
                name: "updated_user_id",
                table: "statistics",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "updated_user_id",
                table: "services",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "created_user_id",
                table: "services",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "roles",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<short>(
                name: "updated_user_id",
                table: "fields",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "created_user_id",
                table: "fields",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "updated_user_id",
                table: "faqs",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "created_user_id",
                table: "faqs",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 20, 56, 21, 884, DateTimeKind.Utc).AddTicks(1509),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 20, 21, 46, 493, DateTimeKind.Utc).AddTicks(6655));

            migrationBuilder.AlterColumn<short>(
                name: "updated_user_id",
                table: "comments",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "created_user_id",
                table: "comments",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "updated_user_id",
                table: "clients",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "created_user_id",
                table: "clients",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "clients",
                type: "bit",
                nullable: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "clients");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "team_members",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<long>(
                name: "updated_user_id",
                table: "statistics",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "updated_user_id",
                table: "services",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_user_id",
                table: "services",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                table: "roles",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_date",
                table: "roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "updated_user_id",
                table: "fields",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_user_id",
                table: "fields",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "updated_user_id",
                table: "faqs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_user_id",
                table: "faqs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "request_date",
                table: "contact_us_requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 27, 20, 21, 46, 493, DateTimeKind.Utc).AddTicks(6655),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 27, 20, 56, 21, 884, DateTimeKind.Utc).AddTicks(1509));

            migrationBuilder.AlterColumn<long>(
                name: "updated_user_id",
                table: "comments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_user_id",
                table: "comments",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "updated_user_id",
                table: "clients",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "created_user_id",
                table: "clients",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);
        }
    }
}
