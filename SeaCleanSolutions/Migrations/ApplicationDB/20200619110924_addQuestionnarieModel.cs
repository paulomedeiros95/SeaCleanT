using Microsoft.EntityFrameworkCore.Migrations;

namespace SeaCleanSolutions.Migrations.ApplicationDB
{
    public partial class addQuestionnarieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaries",
                columns: table => new
                {
                    QuestionnarieID = table.Column<string>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: false),
                    AnswersOptions = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaries", x => new { x.QuestionnarieID, x.QuestionNumber });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questionnaries");
        }
    }
}
