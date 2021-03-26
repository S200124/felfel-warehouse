using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelfelWarehouse.Migrations
{
    public partial class CorrectDefaultTimestamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 159, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 153, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "movements",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 262, DateTimeKind.Local).AddTicks(5238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "movements",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 262, DateTimeKind.Local).AddTicks(4827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "batches",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 162, DateTimeKind.Local).AddTicks(2822));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "batches",
                type: "datetime",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 162, DateTimeKind.Local).AddTicks(2456));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 159, DateTimeKind.Local).AddTicks(8679),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 153, DateTimeKind.Local).AddTicks(3924),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "movements",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 262, DateTimeKind.Local).AddTicks(5238),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "movements",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 262, DateTimeKind.Local).AddTicks(4827),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "batches",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 162, DateTimeKind.Local).AddTicks(2822),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "batches",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 162, DateTimeKind.Local).AddTicks(2456),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
