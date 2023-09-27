using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Marketing",
                table: "Marketing");

            migrationBuilder.RenameTable(
                name: "Marketing",
                newName: "Campanha");

            migrationBuilder.RenameColumn(
                name: "Nome_Marketing",
                table: "Campanha",
                newName: "Nome_Campanha");

            migrationBuilder.RenameColumn(
                name: "Id_Marketing",
                table: "Campanha",
                newName: "Id_Campanha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha",
                column: "Id_Campanha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Campanha",
                table: "Campanha");

            migrationBuilder.RenameTable(
                name: "Campanha",
                newName: "Marketing");

            migrationBuilder.RenameColumn(
                name: "Nome_Campanha",
                table: "Marketing",
                newName: "Nome_Marketing");

            migrationBuilder.RenameColumn(
                name: "Id_Campanha",
                table: "Marketing",
                newName: "Id_Marketing");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marketing",
                table: "Marketing",
                column: "Id_Marketing");
        }
    }
}
