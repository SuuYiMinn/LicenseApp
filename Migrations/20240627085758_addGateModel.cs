using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicenseApp.Migrations
{
    /// <inheritdoc />
    public partial class addGateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GateId",
                table: "Sakhans",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SakhanId = table.Column<int>(type: "int", nullable: false),
                    SakhanName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gates", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sakhans_Gates_GateId",
                table: "Sakhans");

            migrationBuilder.DropTable(
                name: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Sakhans_GateId",
                table: "Sakhans");

            migrationBuilder.DropColumn(
                name: "GateId",
                table: "Sakhans");
        }
    }
}
