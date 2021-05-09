using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class allTheModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonateNecisities");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "MoneyDonation");

            migrationBuilder.DropColumn(
                name: "DonateField",
                table: "Association");

            migrationBuilder.AddColumn<int>(
                name: "PurposeId",
                table: "MoneyDonation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decscription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssociationCommunityWorks",
                columns: table => new
                {
                    AssociationId = table.Column<int>(type: "int", nullable: false),
                    CommunityWorksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationCommunityWorks", x => new { x.AssociationId, x.CommunityWorksId });
                    table.ForeignKey(
                        name: "FK_AssociationCommunityWorks_Association_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationCommunityWorks_CommunityWorks_CommunityWorksId",
                        column: x => x.CommunityWorksId,
                        principalTable: "CommunityWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssociationPurpose",
                columns: table => new
                {
                    AssociationIdId = table.Column<int>(type: "int", nullable: false),
                    PurposesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssociationPurpose", x => new { x.AssociationIdId, x.PurposesId });
                    table.ForeignKey(
                        name: "FK_AssociationPurpose_Association_AssociationIdId",
                        column: x => x.AssociationIdId,
                        principalTable: "Association",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssociationPurpose_Purpose_PurposesId",
                        column: x => x.PurposesId,
                        principalTable: "Purpose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyDonation_PurposeId",
                table: "MoneyDonation",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationCommunityWorks_CommunityWorksId",
                table: "AssociationCommunityWorks",
                column: "CommunityWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_AssociationPurpose_PurposesId",
                table: "AssociationPurpose",
                column: "PurposesId");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_AssociationId",
                table: "Branch",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_AssociationId",
                table: "Manager",
                column: "AssociationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyDonation_Purpose_PurposeId",
                table: "MoneyDonation",
                column: "PurposeId",
                principalTable: "Purpose",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyDonation_Purpose_PurposeId",
                table: "MoneyDonation");

            migrationBuilder.DropTable(
                name: "AssociationCommunityWorks");

            migrationBuilder.DropTable(
                name: "AssociationPurpose");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "CommunityWorks");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.DropIndex(
                name: "IX_MoneyDonation_PurposeId",
                table: "MoneyDonation");

            migrationBuilder.DropColumn(
                name: "PurposeId",
                table: "MoneyDonation");

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "MoneyDonation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonateField",
                table: "Association",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DonateNecisities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    whoIsFor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonateNecisities", x => x.Id);
                });
        }
    }
}
