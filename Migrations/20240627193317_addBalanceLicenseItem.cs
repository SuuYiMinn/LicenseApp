using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseApp.Migrations
{
    /// <inheritdoc />
    public partial class addBalanceLicenseItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "LicenseItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "LicenseItems");
        }
    }
}
