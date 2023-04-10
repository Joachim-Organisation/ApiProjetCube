using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjetCube.Migrations
{
    /// <inheritdoc />
    public partial class miseenplacedumotdepassedansutilisateur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Utilisateurs",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Utilisateurs");
        }
    }
}
