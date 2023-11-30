using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacionIII.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_SaleOrderLines_SaleOrderLineId",
                table: "SaleOrders");

            migrationBuilder.DropTable(
                name: "ProductSaleOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_SaleOrderLineId",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "SaleOrderLineId",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "test",
                table: "SaleOrders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleOrderLineId",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "test",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductSaleOrderLine",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SaleOrderLinesSaleOrderLineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSaleOrderLine", x => new { x.ProductsId, x.SaleOrderLinesSaleOrderLineId });
                    table.ForeignKey(
                        name: "FK_ProductSaleOrderLine_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSaleOrderLine_SaleOrderLines_SaleOrderLinesSaleOrderLineId",
                        column: x => x.SaleOrderLinesSaleOrderLineId,
                        principalTable: "SaleOrderLines",
                        principalColumn: "SaleOrderLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_SaleOrderLineId",
                table: "SaleOrders",
                column: "SaleOrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleOrderLine_SaleOrderLinesSaleOrderLineId",
                table: "ProductSaleOrderLine",
                column: "SaleOrderLinesSaleOrderLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_SaleOrderLines_SaleOrderLineId",
                table: "SaleOrders",
                column: "SaleOrderLineId",
                principalTable: "SaleOrderLines",
                principalColumn: "SaleOrderLineId");
        }
    }
}
