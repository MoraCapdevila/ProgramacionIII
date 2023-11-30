using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacionIII.Migrations
{
    /// <inheritdoc />
    public partial class newColumna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "SaleOrders",
                newName: "test");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "test",
                table: "SaleOrders",
                newName: "OrderId");
        }
    }
}
