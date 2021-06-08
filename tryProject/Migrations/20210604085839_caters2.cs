using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class caters2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Association_CatersTo_CatersToId",
                table: "Association");

            migrationBuilder.DropForeignKey(
                name: "FK_AssociationZone_Association_AssociationsId",
                table: "AssociationZone");

            migrationBuilder.DropIndex(
                name: "IX_Association_CatersToId",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "CatersToId",
                table: "Association");

            migrationBuilder.RenameColumn(
                name: "AssociationsId",
                table: "AssociationZone",
                newName: "AssociationId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Zone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AssociationCatersTo",
                columns: table => new
                {
                    AssociationsId = table.Column<int>(type: "int", nullable: false),
                    Caters2Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationCatersTo", x => new { x.AssociationsId, x.Caters2Id });
                    table.ForeignKey(
                        name: "FK_AssociationCatersTo_Association_AssociationsId",
                        column: x => x.AssociationsId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationCatersTo_CatersTo_Caters2Id",
                        column: x => x.Caters2Id,
                        principalTable: "CatersTo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssociationCatersTo_Caters2Id",
                table: "AssociationCatersTo",
                column: "Caters2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationZone_Association_AssociationId",
                table: "AssociationZone",
                column: "AssociationId",
                principalTable: "Association",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationZone_Association_AssociationId",
                table: "AssociationZone");

            migrationBuilder.DropTable(
                name: "AssociationCatersTo");

            migrationBuilder.RenameColumn(
                name: "AssociationId",
                table: "AssociationZone",
                newName: "AssociationsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Zone",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CatersToId",
                table: "Association",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Association_CatersToId",
                table: "Association",
                column: "CatersToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Association_CatersTo_CatersToId",
                table: "Association",
                column: "CatersToId",
                principalTable: "CatersTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationZone_Association_AssociationsId",
                table: "AssociationZone",
                column: "AssociationsId",
                principalTable: "Association",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
