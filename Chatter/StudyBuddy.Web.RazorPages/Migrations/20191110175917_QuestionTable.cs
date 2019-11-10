using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyBuddy.Web.RazorPages.Migrations
{
    public partial class QuestionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    questionid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentname = table.Column<string>(maxLength: 50, nullable: false),
                    teachername = table.Column<string>(maxLength: 50, nullable: false),
                    subjectitle = table.Column<string>(maxLength: 50, nullable: false),
                    message = table.Column<string>(maxLength: 500, nullable: false),
                    status = table.Column<int>(nullable: false),
                    answer = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.questionid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Question");
        }
    }
}
