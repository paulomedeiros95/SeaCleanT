using Microsoft.EntityFrameworkCore.Migrations;

namespace SeaCleanSolutions.Migrations.ApplicationDB
{
    public partial class ApplicationDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseName = table.Column<string>(nullable: false),
                    AuthorName = table.Column<string>(nullable: false),
                    CreatedTo = table.Column<string>(nullable: false),
                    PhotoGroup = table.Column<string>(nullable: false),
                    QuestionnarieName = table.Column<string>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseName);
                });

            migrationBuilder.CreateTable(
                name: "ImageDocs",
                columns: table => new
                {
                    PhotoName = table.Column<string>(nullable: false),
                    PhotoGroup = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDocs", x => new { x.PhotoName, x.PhotoGroup });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "ImageDocs");
        }
    }
}
