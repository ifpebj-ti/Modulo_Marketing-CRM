﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModuloMarketing.Api.Repository;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    [DbContext(typeof(DbContexto))]
    partial class DbContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Campanha", b =>
                {
                    b.Property<int>("Id_Marketing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Marketing"));

                    b.Property<DateTime>("Data_Inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Data_Termino")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Email_Criador")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Id_Resultado")
                        .HasColumnType("integer");

                    b.Property<string>("Nome_Marketing")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("Possui_Disparo_Mensagem")
                        .HasColumnType("boolean");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("mensagem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Marketing");

                    b.HasIndex("Id_Resultado");

                    b.ToTable("Marketing");
                });

            modelBuilder.Entity("ModuloMarketing.Api.Domain.Canal", b =>
                {
                    b.Property<int>("Id_Canal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Canal"));

                    b.Property<string>("Nome_Canal")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Canal");

                    b.ToTable("Canal");
                });

            modelBuilder.Entity("ModuloMarketing.Api.Domain.Categoria", b =>
                {
                    b.Property<int>("Id_Categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Categoria"));

                    b.Property<string>("Nome_Categoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Categoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ModuloMarketing.Api.Domain.HistoricoCampanhas", b =>
                {
                    b.Property<int>("Id_Historico_Campanha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Historico_Campanha"));

                    b.Property<DateOnly>("Data_Fim")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Data_Inicio")
                        .HasColumnType("date");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Id_Campanha")
                        .HasColumnType("integer");

                    b.Property<int>("Id_Resultado_Campanha")
                        .HasColumnType("integer");

                    b.HasKey("Id_Historico_Campanha");

                    b.ToTable("HistoricoCampanhas");
                });

            modelBuilder.Entity("ModuloMarketing.Api.Domain.ProdutosEmPromocao", b =>
                {
                    b.Property<int>("ID_Promocao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Promocao"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("numeric");

                    b.Property<int>("ID_Produto")
                        .HasColumnType("integer");

                    b.HasKey("ID_Promocao");

                    b.HasIndex("ID_Produto");

                    b.ToTable("ProdutosEmPromocao");
                });

            modelBuilder.Entity("Produto", b =>
                {
                    b.Property<int>("ID_Produto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID_Produto"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Fornecedor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("integer");

                    b.HasKey("ID_Produto");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("ResultadoCampanha", b =>
                {
                    b.Property<int>("Id_Resultado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Resultado"));

                    b.Property<int>("Alcance")
                        .HasColumnType("integer");

                    b.Property<int>("Id_Campanha")
                        .HasColumnType("integer");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Resultado");

                    b.ToTable("ResultadoMarketing");
                });

            modelBuilder.Entity("Campanha", b =>
                {
                    b.HasOne("ResultadoCampanha", "Resultado_Campanha")
                        .WithMany()
                        .HasForeignKey("Id_Resultado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resultado_Campanha");
                });

            modelBuilder.Entity("ModuloMarketing.Api.Domain.ProdutosEmPromocao", b =>
                {
                    b.HasOne("Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ID_Produto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
