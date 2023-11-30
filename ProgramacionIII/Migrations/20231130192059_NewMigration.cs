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
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "SaleOrders");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "SaleOrders");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "SaleOrders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "SaleOrders",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
