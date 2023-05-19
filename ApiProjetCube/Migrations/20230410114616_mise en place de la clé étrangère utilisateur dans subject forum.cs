using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjetCube.Migrations
{
    /// <inheritdoc />
    public partial class miseenplacedelacléétrangèreutilisateurdanssubjectforum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUtilisateur",
                table: "SubjectsForums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsForums_IdUtilisateur",
                table: "SubjectsForums",
                column: "IdUtilisateur");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectsForums_Utilisateur",
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
                name: "FK_SubjectsForums_Utilisateur",
                table: "SubjectsForums");

            migrationBuilder.DropIndex(
                name: "IX_SubjectsForums_IdUtilisateur",
                table: "SubjectsForums");

            migrationBuilder.DropColumn(
                name: "IdUtilisateur",
                table: "SubjectsForums");
        }
    }
}
