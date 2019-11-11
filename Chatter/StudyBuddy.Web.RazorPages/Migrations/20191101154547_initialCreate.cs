using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyBuddy.Web.RazorPages.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id1 = table.Column<int>(nullable: false),
                    id2 = table.Column<int>(nullable: false),
                    text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    subjectid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.subjectid);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subjectid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subjects__ACE14378B63CB419", x => x.subjectid);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    subjectid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nick = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(maxLength: 50, nullable: false),
                    profession = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Table__3214EC079493A81A", x => x.subjectid);
                });

            migrationBuilder.CreateTable(
                name: "Teaching",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false),
                    subjectid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tmp_ms_x__516FA6603C8B3913", x => new { x.userid, x.subjectid });
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nick = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(maxLength: 50, nullable: false),
                    profession = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userid);
                });
                */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Teaching");

            migrationBuilder.DropTable(
                name: "User");*/
        }
    }
}
