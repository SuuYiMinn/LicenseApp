using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseApp.Migrations
{
    /// <inheritdoc />
    public partial class addSakhanShortNameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SakhanShortName",
                table: "Sakhans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SakhanShortName",
                table: "Sakhans");
        }
    }
}
