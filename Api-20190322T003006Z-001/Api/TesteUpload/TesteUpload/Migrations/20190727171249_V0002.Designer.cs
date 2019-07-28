﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TesteUpload.Migrations
{
    [DbContext(typeof(UP7WebApiContext))]
    [Migration("20190727171249_V0002")]
    partial class V0002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteUpload.Model.CarroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .IsRequired();

                    b.Property<string>("ArCondicionado");

                    b.Property<string>("Bancos");

                    b.Property<string>("CaminhoImagem");

                    b.Property<bool?>("CarroAntigo");

                    b.Property<bool?>("CarroSeminovo");

                    b.Property<string>("Cor");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("Descricao");

                    b.Property<string>("Freios");

                    b.Property<string>("Marca")
                        .IsRequired();

                    b.Property<string>("Modelo")
                        .IsRequired();

                    b.Property<string>("PaisOrigem");

                    b.Property<string>("Potencia");

                    b.Property<string>("Preco");

                    b.Property<string>("Quilometragem");

                    b.Property<string>("Rodas");

                    b.Property<string>("StatusCarro");

                    b.Property<string>("Tracao");

                    b.Property<string>("Vidros");

                    b.HasKey("Id");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("TesteUpload.Model.CodigoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo");

                    b.Property<int>("IdRifa");

                    b.Property<int>("Numero");

                    b.HasKey("Id");

                    b.HasIndex("IdRifa");

                    b.ToTable("Codigo");
                });

            modelBuilder.Entity("TesteUpload.Model.EventoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Imagem")
                        .IsRequired();

                    b.Property<int>("Mes");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("TesteUpload.Model.ImagemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caminho");

                    b.Property<int?>("CarroId");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.ToTable("imagens");
                });

            modelBuilder.Entity("TesteUpload.Model.InstituicaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Imagem");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("TesteUpload.Model.ParceiroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Imagem")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Parceiros");
                });

            modelBuilder.Entity("TesteUpload.Model.RifaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .IsRequired();

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Imagem")
                        .IsRequired();

                    b.Property<string>("Preco")
                        .IsRequired();

                    b.Property<int>("QuantidadaRestante");

                    b.Property<int>("Quantidade");

                    b.Property<int>("QuantidadePendente");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("Rifa");
                });

            modelBuilder.Entity("TesteUpload.Model.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Ativo");

                    b.Property<int>("CodigoRifa");

                    b.Property<string>("Estado")
                        .IsRequired();

                    b.Property<bool?>("Ganhador");

                    b.Property<int>("IdRifa");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.Property<DateTime>("dataOperacao");

                    b.HasKey("Id");

                    b.HasIndex("IdRifa");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TesteUpload.Model.CodigoModel", b =>
                {
                    b.HasOne("TesteUpload.Model.RifaModel", "Rifa")
                        .WithMany("CodigoRifa")
                        .HasForeignKey("IdRifa")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TesteUpload.Model.ImagemModel", b =>
                {
                    b.HasOne("TesteUpload.Model.CarroModel", "Carro")
                        .WithMany("Imagem")
                        .HasForeignKey("CarroId");
                });

            modelBuilder.Entity("TesteUpload.Model.UsuarioModel", b =>
                {
                    b.HasOne("TesteUpload.Model.RifaModel", "Rifa")
                        .WithMany("Usuario")
                        .HasForeignKey("IdRifa")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}