using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Marketing",
                columns: table => new
                {
                    Id_Marketing = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome_Marketing = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email_Criador = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    Data_Termino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Possui_Disparo_Mensagem = table.Column<bool>(type: "boolean", nullable: false),
                    mensagem = table.Column<string>(type: "text", nullable: false),
                    Alcance = table.Column<int>(type: "integer", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketing", x => x.Id_Marketing);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canal");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "HistoricoCampanhas");

            migrationBuilder.DropTable(
                name: "Marketing");
        }
    }
}
