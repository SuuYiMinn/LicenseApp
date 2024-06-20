using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseApp.Migrations
{
    /// <inheritdoc />
    public partial class addAppItemModifyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ApplicationItem");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "ApplicationItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationItem_UnitId",
                table: "ApplicationItem",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationItem_Units_UnitId",
                table: "ApplicationItem",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationItem_Units_UnitId",
                table: "ApplicationItem");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationItem_UnitId",
                table: "ApplicationItem");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "ApplicationItem");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ApplicationItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
