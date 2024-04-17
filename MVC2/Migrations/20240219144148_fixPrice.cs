using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC2.Migrations
{
    /// <inheritdoc />
    public partial class fixPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(2,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
