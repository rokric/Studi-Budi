using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyBuddy.Web.RazorPages.Migrations
{
    public partial class fk_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Teaching_subjectid",
                table: "Teaching",
                column: "subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectRequest_userid",
                table: "SubjectRequest",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Report_userid",
                table: "Report",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_subjectID",
                table: "FAQ",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_teacherID",
                table: "FAQ",
                column: "teacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_FAQ_Subject_subjectID",
                table: "FAQ",
                column: "subjectID",
                principalTable: "Subject",
                principalColumn: "subjectid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FAQ_User_teacherID",
                table: "FAQ",
                column: "teacherID",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_User_userid",
                table: "Report",
                column: "userid",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectRequest_User_userid",
                table: "SubjectRequest",
                column: "userid",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teaching_Subject_subjectid",
                table: "Teaching",
                column: "subjectid",
                principalTable: "Subject",
                principalColumn: "subjectid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teaching_User_userid",
                table: "Teaching",
                column: "userid",
                principalTable: "User",
                principalColumn: "userid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FAQ_Subject_subjectID",
                table: "FAQ");

            migrationBuilder.DropForeignKey(
                name: "FK_FAQ_User_teacherID",
                table: "FAQ");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_User_userid",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectRequest_User_userid",
                table: "SubjectRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Teaching_Subject_subjectid",
                table: "Teaching");

            migrationBuilder.DropForeignKey(
                name: "FK_Teaching_User_userid",
                table: "Teaching");

            migrationBuilder.DropIndex(
                name: "IX_Teaching_subjectid",
                table: "Teaching");

            migrationBuilder.DropIndex(
                name: "IX_SubjectRequest_userid",
                table: "SubjectRequest");

            migrationBuilder.DropIndex(
                name: "IX_Report_userid",
                table: "Report");

            migrationBuilder.DropIndex(
                name: "IX_FAQ_subjectID",
                table: "FAQ");

            migrationBuilder.DropIndex(
                name: "IX_FAQ_teacherID",
                table: "FAQ");
        }
    }
}
