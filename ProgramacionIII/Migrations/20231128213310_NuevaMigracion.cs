using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacionIII.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrderLines_SaleOrders_SaleOrderId",
                table: "SaleOrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleOrders",
                table: "SaleOrders");

            migrationBuilder.DropIndex(
                name: "IX_Products_AdminId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SaleOrderId",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SaleOrders",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "SaleOrders",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalPrice",
                table: "SaleOrderLines",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleOrders",
                table: "SaleOrders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 2000f);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 5000f);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrderLines_SaleOrders_SaleOrderId",
                table: "SaleOrderLines",
                column: "SaleOrderId",
                principalTable: "SaleOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleOrderLines_SaleOrders_SaleOrderId",
                table: "SaleOrderLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleOrders",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "SaleOrders");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "SaleOrderLines");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SaleOrders",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "SaleOrderId",
                table: "SaleOrders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Products",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleOrders",
                table: "SaleOrders",
                column: "SaleOrderId");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdminId", "Price" },
                values: new object[] { null, 2000m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AdminId", "Price" },
                values: new object[] { null, 5000m });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AdminId",
                table: "Products",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AdminId",
                table: "Products",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleOrderLines_SaleOrders_SaleOrderId",
                table: "SaleOrderLines",
                column: "SaleOrderId",
                principalTable: "SaleOrders",
                principalColumn: "SaleOrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
