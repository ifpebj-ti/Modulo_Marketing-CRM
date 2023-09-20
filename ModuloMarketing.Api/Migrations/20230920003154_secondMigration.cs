using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marketing_ResultadoMarketing_Id_Resuldado",
                table: "Marketing");

            migrationBuilder.DropIndex(
                name: "IX_Marketing_Id_Resuldado",
                table: "Marketing");

            migrationBuilder.DropColumn(
                name: "Id_Resuldado",
                table: "Marketing");

            migrationBuilder.RenameColumn(
                name: "Id_Marketing",
                table: "ResultadoMarketing",
                newName: "Id_Campanha");

            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "Marketing",
                newName: "mensagem");

            migrationBuilder.RenameColumn(
                name: "DataTermino",
                table: "Marketing",
                newName: "Data_Termino");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Marketing",
                newName: "Data_Inicio");

            migrationBuilder.AddColumn<bool>(
                name: "Possui_Disparo_Mensagem",
                table: "Marketing",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Canal",
                columns: table => new
                {
                    Id_Canal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_Canal = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canal", x => x.Id_Canal);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_Categoria = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoCampanhas",
                columns: table => new
                {
                    Id_Historico_Campanha = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Campanha = table.Column<int>(type: "integer", nullable: false),
                    Id_Resultado_Campanha = table.Column<int>(type: "integer", nullable: false),
                    Data_Inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    Data_Fim = table.Column<DateOnly>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCampanhas", x => x.Id_Historico_Campanha);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marketing_Id_Resultado",
                table: "Marketing",
                column: "Id_Resultado");

            migrationBuilder.AddForeignKey(
                name: "FK_Marketing_ResultadoMarketing_Id_Resultado",
                table: "Marketing",
                column: "Id_Resultado",
                principalTable: "ResultadoMarketing",
                principalColumn: "Id_Resultado",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marketing_ResultadoMarketing_Id_Resultado",
                table: "Marketing");

            migrationBuilder.DropTable(
                name: "Canal");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "HistoricoCampanhas");

            migrationBuilder.DropIndex(
                name: "IX_Marketing_Id_Resultado",
                table: "Marketing");

            migrationBuilder.DropColumn(
                name: "Possui_Disparo_Mensagem",
                table: "Marketing");

            migrationBuilder.RenameColumn(
                name: "Id_Campanha",
                table: "ResultadoMarketing",
                newName: "Id_Marketing");

            migrationBuilder.RenameColumn(
                name: "mensagem",
                table: "Marketing",
                newName: "Observacao");

            migrationBuilder.RenameColumn(
                name: "Data_Termino",
                table: "Marketing",
                newName: "DataTermino");

            migrationBuilder.RenameColumn(
                name: "Data_Inicio",
                table: "Marketing",
                newName: "DataInicio");

            migrationBuilder.AddColumn<int>(
                name: "Id_Resuldado",
                table: "Marketing",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Marketing_Id_Resuldado",
                table: "Marketing",
                column: "Id_Resuldado");

            migrationBuilder.AddForeignKey(
                name: "FK_Marketing_ResultadoMarketing_Id_Resuldado",
                table: "Marketing",
                column: "Id_Resuldado",
                principalTable: "ResultadoMarketing",
                principalColumn: "Id_Resultado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
