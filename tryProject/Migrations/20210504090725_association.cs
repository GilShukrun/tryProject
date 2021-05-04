using Microsoft.EntityFrameworkCore.Migrations;

namespace tryProject.Migrations
{
    public partial class association : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sum",
                table: "MoneyDonation",
                newName: "Sum");

            migrationBuilder.RenameColumn(
                name: "purpose",
                table: "MoneyDonation",
                newName: "Purpose");

            migrationBuilder.RenameColumn(
                name: "area",
                table: "DonateNecisities",
                newName: "Area");

            migrationBuilder.CreateTable(
                name: "Association",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonateField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Association", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Association");

            migrationBuilder.RenameColumn(
                name: "Sum",
                table: "MoneyDonation",
                newName: "sum");

            migrationBuilder.RenameColumn(
                name: "Purpose",
                table: "MoneyDonation",
                newName: "purpose");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "DonateNecisities",
                newName: "area");
        }
    }
}
