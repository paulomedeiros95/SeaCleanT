using Microsoft.EntityFrameworkCore.Migrations;

namespace SeaCleanSolutions.Migrations.ApplicationDB
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageDoc");

            migrationBuilder.AddColumn<string>(
                name: "PhotoGroup",
                table: "Courses",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoGroup",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "ImageDoc",
                columns: table => new
                {
                    PhotoPath = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
    }
}
