using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyBuddy.Web.RazorPages.Migrations
{
    public partial class new_field_FAQ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subjectID",
                table: "FAQ",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subjectID",
                table: "FAQ");
        }
    }
}
