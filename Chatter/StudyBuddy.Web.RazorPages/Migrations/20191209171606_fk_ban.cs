using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyBuddy.Web.RazorPages.Migrations
{
    public partial class fk_ban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ban_userid",
                table: "Ban",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Ban_User_userid",
                table: "Ban",
                column: "userid",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ban_User_userid",
                table: "Ban");

            migrationBuilder.DropIndex(
                name: "IX_Ban_userid",
                table: "Ban");
        }
    }
}
