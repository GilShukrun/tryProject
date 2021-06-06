using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class cater2check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationCatersTo_CatersTo_Caters2Id",
                table: "AssociationCatersTo");

            migrationBuilder.RenameColumn(
                name: "Caters2Id",
                table: "AssociationCatersTo",
                newName: "CatersToId");

            migrationBuilder.RenameIndex(
                name: "IX_AssociationCatersTo_Caters2Id",
                table: "AssociationCatersTo",
                newName: "IX_AssociationCatersTo_CatersToId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationCatersTo_CatersTo_CatersToId",
                table: "AssociationCatersTo",
                column: "CatersToId",
                principalTable: "CatersTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationCatersTo_CatersTo_CatersToId",
                table: "AssociationCatersTo");

            migrationBuilder.RenameColumn(
                name: "CatersToId",
                table: "AssociationCatersTo",
                newName: "Caters2Id");

            migrationBuilder.RenameIndex(
                name: "IX_AssociationCatersTo_CatersToId",
                table: "AssociationCatersTo",
                newName: "IX_AssociationCatersTo_Caters2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationCatersTo_CatersTo_Caters2Id",
                table: "AssociationCatersTo",
                column: "Caters2Id",
                principalTable: "CatersTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
