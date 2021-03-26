using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FelfelWarehouse.Migrations
{
    public partial class CreateBatchAndMovementTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 153, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 159, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.CreateTable(
                name: "batches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 162, DateTimeKind.Local).AddTicks(2456)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 162, DateTimeKind.Local).AddTicks(2822))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batches_Products",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "movements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 262, DateTimeKind.Local).AddTicks(4827)),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 3, 26, 22, 30, 22, 262, DateTimeKind.Local).AddTicks(5238))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_Batches",
                        column: x => x.BatchId,
                        principalTable: "batches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_batches_ProductId",
                table: "batches",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_movements_BatchId",
                table: "movements",
                column: "BatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movements");

            migrationBuilder.DropTable(
                name: "batches");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "products");
        }
    }
}
