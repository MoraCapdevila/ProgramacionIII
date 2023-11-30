using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacionIII.Migrations
{
    /// <inheritdoc />
    public partial class SalesOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_Users_AdminId",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "SaleOrders");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "SaleOrders",
                newName: "SaleOrderLineId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOrders_AdminId",
                table: "SaleOrders",
                newName: "IX_SaleOrders_SaleOrderLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_SaleOrderLines_SaleOrderLineId",
                table: "SaleOrders",
                column: "SaleOrderLineId",
                principalTable: "SaleOrderLines",
                principalColumn: "SaleOrderLineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrders_SaleOrderLines_SaleOrderLineId",
                table: "SaleOrders");

            migrationBuilder.RenameColumn(
                name: "SaleOrderLineId",
                table: "SaleOrders",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleOrders_SaleOrderLineId",
                table: "SaleOrders",
                newName: "IX_SaleOrders_AdminId");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "SaleOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrders_Users_AdminId",
                table: "SaleOrders",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
