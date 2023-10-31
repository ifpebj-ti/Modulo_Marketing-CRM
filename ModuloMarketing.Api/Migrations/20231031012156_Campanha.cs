using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    /// <inheritdoc />
    public partial class Campanha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Criacao",
                table: "Campanha",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nome_Criador",
                table: "Campanha",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Valor_Meta",
                table: "Campanha",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Criacao",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "Nome_Criador",
                table: "Campanha");

            migrationBuilder.DropColumn(
                name: "Valor_Meta",
                table: "Campanha");
        }
    }
}
