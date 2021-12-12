using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Infrastructure.Migrations
{
    public partial class SalesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "SalesOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SalesOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "SalesOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Qty",
                table: "SalesOrders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "QtyOnHand",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Products_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_ProductId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "SalesOrders");

            migrationBuilder.AlterColumn<long>(
                name: "QtyOnHand",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
