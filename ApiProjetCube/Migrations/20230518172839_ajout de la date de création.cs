using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjetCube.Migrations
{
    /// <inheritdoc />
    public partial class ajoutdeladatedecréation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_SubjectForums",
                table: "MessagesForums");

            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_Utilisateurs",
                table: "MessagesForums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsForums_Utilisateur",
                table: "SubjectsForums");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreation",
                table: "MessagesForums",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesForums_SubjectsForums_IdSubjectForum",
                table: "MessagesForums",
                column: "IdSubjectForum",
                principalTable: "SubjectsForums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MessagesForums_Utilisateurs_IdUtilisateur",
                table: "MessagesForums",
                column: "IdUtilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsForums_Utilisateurs_IdUtilisateur",
                table: "SubjectsForums",
                column: "IdUtilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_SubjectsForums_IdSubjectForum",
                table: "MessagesForums");

            migrationBuilder.DropForeignKey(
                name: "FK_MessagesForums_Utilisateurs_IdUtilisateur",
                table: "MessagesForums");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectsForums_Utilisateurs_IdUtilisateur",
                table: "SubjectsForums");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreation",
                table: "MessagesForums",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetime(6)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsForums_Utilisateur",
                table: "SubjectsForums",
                column: "IdUtilisateur",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
