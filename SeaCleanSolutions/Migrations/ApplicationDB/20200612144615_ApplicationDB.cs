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
                    QuestionnarieName = table.Column<string>(nullable: false),
                    VideoUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseName);
                });

            migrationBuilder.CreateTable(
                name: "ImageDoc",
                columns: table => new
                {
                    PhotoPath = table.Column<string>(nullable: false),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDoc", x => x.PhotoPath);
                    table.ForeignKey(
                        name: "FK_ImageDoc_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageDoc_CourseName",
                table: "ImageDoc",
                column: "CourseName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageDoc");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
