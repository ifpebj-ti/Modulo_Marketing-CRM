using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    /// <inheritdoc />
    public partial class RecorrenciaCampanhas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dia_Da_Semana_Da_Recorrencia",
                table: "Campanha",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dia_Do_Mes_Da_Recorrencia",
                table: "Campanha",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Frequencia",
                table: "Campanha",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Frequencia_de_Repeticao",
                table: "Campanha",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Recorrente",
                table: "Campanha",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dia_Da_Semana_Da_Recorrencia",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "Dia_Do_Mes_Da_Recorrencia",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "Frequencia",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "Frequencia_de_Repeticao",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "Recorrente",
                table: "Campanha");
        }
    }
}
