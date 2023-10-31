﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModuloMarketing.Api.Repository;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ModuloMarketing.Api.Migrations
{
    [DbContext(typeof(DbContexto))]
    [Migration("20231031012156_Campanha")]
    partial class Campanha
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Id_Campanha")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Campanha"));

                    b.Property<int>("Alcance")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data_Criacao")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<string>("Nome_Campanha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Nome_Criador")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Possui_Disparo_Mensagem")
                        .HasColumnType("boolean");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<double>("Valor_Meta")
                        .HasColumnType("double precision");

                    b.Property<string>("mensagem")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Campanha");

                    b.ToTable("Campanha");
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

            modelBuilder.Entity("ModuloMarketing.Api.Domain.DataComemorativa", b =>
                {
                    b.Property<int>("Id_Comemorativa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Comemorativa"));

                    b.Property<int>("Dia")
                        .HasColumnType("integer");

                    b.Property<int>("Mes")
                        .HasColumnType("integer");

                    b.Property<string>("Nome_Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Comemorativa");

                    b.ToTable("DataComemorativa");
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
#pragma warning restore 612, 618
        }
    }
}
