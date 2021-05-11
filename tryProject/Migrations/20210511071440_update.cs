using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationPurpose_Association_AssociationIdId",
                table: "AssociationPurpose");

            migrationBuilder.RenameColumn(
                name: "AssociationIdId",
                table: "AssociationPurpose",
                newName: "AssociationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationPurpose_Association_AssociationId",
                table: "AssociationPurpose",
                column: "AssociationId",
                principalTable: "Association",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssociationPurpose_Association_AssociationId",
                table: "AssociationPurpose");

            migrationBuilder.RenameColumn(
                name: "AssociationId",
                table: "AssociationPurpose",
                newName: "AssociationIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssociationPurpose_Association_AssociationIdId",
                table: "AssociationPurpose",
                column: "AssociationIdId",
                principalTable: "Association",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
