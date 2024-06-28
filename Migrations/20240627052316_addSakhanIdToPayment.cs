using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseApp.Migrations
{
    /// <inheritdoc />
    public partial class addSakhanIdToPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SakhanId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SakhanId",
                table: "Payments");
        }
    }
}
