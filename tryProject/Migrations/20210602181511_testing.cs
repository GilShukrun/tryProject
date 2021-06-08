using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatersToId",
                table: "Association",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CatersTo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatersTo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrGive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrGive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommunityWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decscription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AssociationId = table.Column<int>(type: "int", nullable: false),
                    WorkOrGiveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunityWorks_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunityWorks_WorkOrGive_WorkOrGiveId",
                        column: x => x.WorkOrGiveId,
                        principalTable: "WorkOrGive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Association_CatersToId",
                table: "Association",
                column: "CatersToId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityWorks_AssociationId",
                table: "CommunityWorks",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityWorks_WorkOrGiveId",
                table: "CommunityWorks",
                column: "WorkOrGiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Association_CatersTo_CatersToId",
                table: "Association",
                column: "CatersToId",
                principalTable: "CatersTo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Association_CatersTo_CatersToId",
                table: "Association");

            migrationBuilder.DropTable(
                name: "CatersTo");

            migrationBuilder.DropTable(
                name: "CommunityWorks");

            migrationBuilder.DropTable(
                name: "WorkOrGive");

            migrationBuilder.DropIndex(
                name: "IX_Association_CatersToId",
                table: "Association");

            migrationBuilder.DropColumn(
                name: "CatersToId",
                table: "Association");
        }
    }
}
