using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseApp.Migrations
{
    /// <inheritdoc />
    public partial class addDbsetLicenseItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseItem_Applications_ApplicationId",
                table: "LicenseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseItem_Items_ItemId",
                table: "LicenseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseItem_Units_UnitId",
                table: "LicenseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseItem",
                table: "LicenseItem");

            migrationBuilder.RenameTable(
                name: "LicenseItem",
                newName: "LicenseItems");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseItem_UnitId",
                table: "LicenseItems",
                newName: "IX_LicenseItems_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseItem_ItemId",
                table: "LicenseItems",
                newName: "IX_LicenseItems_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseItem_ApplicationId",
                table: "LicenseItems",
                newName: "IX_LicenseItems_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseItems",
                table: "LicenseItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseItems_Applications_ApplicationId",
                table: "LicenseItems",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseItems_Items_ItemId",
                table: "LicenseItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseItems_Units_UnitId",
                table: "LicenseItems",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LicenseItems_Applications_ApplicationId",
                table: "LicenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseItems_Items_ItemId",
                table: "LicenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LicenseItems_Units_UnitId",
                table: "LicenseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LicenseItems",
                table: "LicenseItems");

            migrationBuilder.RenameTable(
                name: "LicenseItems",
                newName: "LicenseItem");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseItems_UnitId",
                table: "LicenseItem",
                newName: "IX_LicenseItem_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseItems_ItemId",
                table: "LicenseItem",
                newName: "IX_LicenseItem_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_LicenseItems_ApplicationId",
                table: "LicenseItem",
                newName: "IX_LicenseItem_ApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LicenseItem",
                table: "LicenseItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseItem_Applications_ApplicationId",
                table: "LicenseItem",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseItem_Items_ItemId",
                table: "LicenseItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LicenseItem_Units_UnitId",
                table: "LicenseItem",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
