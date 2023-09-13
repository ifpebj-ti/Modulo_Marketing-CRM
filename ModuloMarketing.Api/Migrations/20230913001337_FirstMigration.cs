using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ID_Produto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeProduto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Categoria = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "integer", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Fornecedor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ID_Produto);
                });

            migrationBuilder.CreateTable(
                name: "ResultadoMarketing",
                columns: table => new
                {
                    Id_Resultado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Marketing = table.Column<int>(type: "integer", nullable: false),
                    Alcance = table.Column<int>(type: "integer", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoMarketing", x => x.Id_Resultado);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosEmPromocao",
                columns: table => new
                {
                    ID_Promocao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ID_Produto = table.Column<int>(type: "integer", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Desconto = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosEmPromocao", x => x.ID_Promocao);
                    table.ForeignKey(
                        name: "FK_ProdutosEmPromocao_Produto_ID_Produto",
                        column: x => x.ID_Produto,
                        principalTable: "Produto",
                        principalColumn: "ID_Produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marketing",
                columns: table => new
                {
                    Id_Marketing = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Resultado = table.Column<int>(type: "integer", nullable: false),
                    Nome_Marketing = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email_Criador = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id_Resuldado = table.Column<int>(type: "integer", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketing", x => x.Id_Marketing);
                    table.ForeignKey(
                        name: "FK_Marketing_ResultadoMarketing_Id_Resuldado",
                        column: x => x.Id_Resuldado,
                        principalTable: "ResultadoMarketing",
                        principalColumn: "Id_Resultado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Marketing_Id_Resuldado",
                table: "Marketing",
                column: "Id_Resuldado");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosEmPromocao_ID_Produto",
                table: "ProdutosEmPromocao",
                column: "ID_Produto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marketing");

            migrationBuilder.DropTable(
                name: "ProdutosEmPromocao");

            migrationBuilder.DropTable(
                name: "ResultadoMarketing");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
