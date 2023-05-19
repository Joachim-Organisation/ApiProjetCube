using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjetCube.Migrations
{
    /// <inheritdoc />
    public partial class AjoutcléétrangèresurMessageForumpourlienavecSubjectForum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_SubjectsForums_SubjectForumId",
                table: "MessagesForums");

            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_Utilisateurs",
                table: "MessagesForums");

            migrationBuilder.DropIndex(
                name: "IX_MessagesForums_SubjectForumId",
                table: "MessagesForums");

            migrationBuilder.DropColumn(
                name: "SubjectForumId",
                table: "MessagesForums");

            migrationBuilder.CreateIndex(
                name: "IX_MessagesForums_IdUtilisateur",
                table: "MessagesForums",
                column: "IdUtilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesForums_SubjectForums",
                table: "MessagesForums",
                column: "IdSubjectForum",
                principalTable: "SubjectsForums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesForums_Utilisateurs",
                table: "MessagesForums",
                column: "IdUtilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_SubjectForums",
                table: "MessagesForums");

            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_Utilisateurs",
                table: "MessagesForums");

            migrationBuilder.DropIndex(
                name: "IX_MessagesForums_IdUtilisateur",
                table: "MessagesForums");

            migrationBuilder.AddColumn<int>(
                name: "SubjectForumId",
                table: "MessagesForums",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MessagesForums_SubjectForumId",
                table: "MessagesForums",
                column: "SubjectForumId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesForums_SubjectsForums_SubjectForumId",
                table: "MessagesForums",
                column: "SubjectForumId",
                principalTable: "SubjectsForums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesForums_Utilisateurs",
                table: "MessagesForums",
                column: "IdSubjectForum",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
