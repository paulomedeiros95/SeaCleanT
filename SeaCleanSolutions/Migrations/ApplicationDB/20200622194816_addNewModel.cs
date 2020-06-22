using Microsoft.EntityFrameworkCore.Migrations;

namespace SeaCleanSolutions.Migrations.ApplicationDB
{
    public partial class addNewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionnarieGroupIDs",
                columns: table => new
                {
                    QGroupID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnarieGroupIDs", x => x.QGroupID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionnarieGroupIDs");
        }
    }
}
