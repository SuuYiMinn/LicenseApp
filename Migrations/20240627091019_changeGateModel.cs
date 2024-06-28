using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseApp.Migrations
{
    /// <inheritdoc />
    public partial class changeGateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sakhans_Gates_GateId",
                table: "Sakhans");

            migrationBuilder.DropIndex(
                name: "IX_Sakhans_GateId",
                table: "Sakhans");

            migrationBuilder.DropColumn(
                name: "GateId",
                table: "Sakhans");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_SakhanId",
                table: "Gates",
                column: "SakhanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Sakhans_SakhanId",
                table: "Gates",
                column: "SakhanId",
                principalTable: "Sakhans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Sakhans_SakhanId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_SakhanId",
                table: "Gates");

            migrationBuilder.AddColumn<int>(
                name: "GateId",
                table: "Sakhans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sakhans_GateId",
                table: "Sakhans",
                column: "GateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sakhans_Gates_GateId",
                table: "Sakhans",
                column: "GateId",
                principalTable: "Gates",
                principalColumn: "Id");
        }
    }
}
