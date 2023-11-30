using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacionIII.Migrations
{
    /// <inheritdoc />
    public partial class newTablita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Products_ProductId",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_SaleOrders_ProductId",
                table: "SaleOrders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "SaleOrders",
                newName: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "SaleOrders",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleOrders_ProductId",
                table: "SaleOrders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Products_ProductId",
                table: "SaleOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
