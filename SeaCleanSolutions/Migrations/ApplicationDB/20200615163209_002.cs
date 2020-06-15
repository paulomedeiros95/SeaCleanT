using Microsoft.EntityFrameworkCore.Migrations;

namespace SeaCleanSolutions.Migrations.ApplicationDB
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageDocs",
                columns: table => new
                {
                    PhotoName = table.Column<string>(nullable: false),
                    PhotoGroup = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDocs", x => x.PhotoName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageDocs");
        }
    }
}
