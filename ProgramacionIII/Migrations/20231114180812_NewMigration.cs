using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacionIII.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminProduct");

            migrationBuilder.DropTable(
                name: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SaleOrderLines",
                newName: "SaleOrderLineId");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "SaleOrders",
                columns: table => new
                {
                    SaleOrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AdminId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleOrders", x => x.SaleOrderId);
                    table.ForeignKey(
                        name: "FK_SaleOrders_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleOrders_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdminId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdminId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_ProductId",
                table: "SaleOrderLines",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrderLines_SaleOrderId",
                table: "SaleOrderLines",
                column: "SaleOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AdminId",
                table: "Products",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSaleOrderLine_SaleOrderLinesSaleOrderLineId",
                table: "ProductSaleOrderLine",
                column: "SaleOrderLinesSaleOrderLineId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_AdminId",
                table: "SaleOrders",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_CustomerId",
                table: "SaleOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrderLines_Products_ProductId",
                table: "SaleOrderLines",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrderLines_SaleOrders_SaleOrderId",
                table: "SaleOrderLines",
                column: "SaleOrderId",
                principalTable: "SaleOrders",
                principalColumn: "SaleOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrderLines_Products_ProductId",
                table: "SaleOrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrderLines_SaleOrders_SaleOrderId",
                table: "SaleOrderLines");

            migrationBuilder.DropTable(
                name: "ProductSaleOrderLine");

            migrationBuilder.DropTable(
                name: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrderLines_ProductId",
                table: "SaleOrderLines");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrderLines_SaleOrderId",
                table: "SaleOrderLines");

            migrationBuilder.DropIndex(
                name: "IX_Products_AdminId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "SaleOrderLineId",
                table: "SaleOrderLines",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "AdminProduct",
                columns: table => new
                {
                    AdminsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminProduct", x => new { x.AdminsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_AdminProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminProduct_Users_AdminsId",
                        column: x => x.AdminsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProduct",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct", x => new { x.CustomersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Users_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdminId = table.Column<int>(type: "INTEGER", nullable: true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalePrice = table.Column<double>(type: "REAL", nullable: false),
                    UseriId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sales_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminProduct_ProductsId",
                table: "AdminProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_ProductsId",
                table: "CustomerProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_AdminId",
                table: "Sales",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }
    }
}
