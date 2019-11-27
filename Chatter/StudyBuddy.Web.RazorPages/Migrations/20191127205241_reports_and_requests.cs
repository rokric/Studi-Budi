using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyBuddy.Web.RazorPages.Migrations
{
    public partial class reports_and_requests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(nullable: false),
                    until = table.Column<DateTime>(nullable: false),
                    message = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectRequest",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userid = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectRequest", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "SubjectRequest");
        }
    }
}
