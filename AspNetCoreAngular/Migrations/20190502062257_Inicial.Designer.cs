﻿// <auto-generated />
using System;
using AspNetCoreAngular.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AspNetCoreAngular.Migrations
{
    [DbContext(typeof(AspNetCoreAngularContext))]
    [Migration("20190502062257_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AspNetCoreAngular.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("CategoriaID");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("AspNetCoreAngular.Entities.Fornecedor", b =>
                {
                    b.Property<int>("FornecedorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CNPJ")
                        .HasColumnType("bigint")
                        .HasMaxLength(14);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.HasKey("FornecedorID");

                    b.ToTable("Fornecedor");
                });

            modelBuilder.Entity("AspNetCoreAngular.Entities.Produto", b =>
                {
                    b.Property<int>("ProdutoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaID");

                    b.Property<int>("CdCategoria");

                    b.Property<int>("CdFornecedor");

                    b.Property<DateTime>("DataFabricacao");

                    b.Property<DateTime>("DataValidade");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<int?>("FornecedorID");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<decimal>("Preco")
                        .HasColumnType("money");

                    b.HasKey("ProdutoID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("FornecedorID");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("AspNetCoreAngular.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(128)")
                        .HasMaxLength(128);

                    b.Property<byte[]>("Senha")
                        .HasColumnType("varbinary(128)")
                        .HasMaxLength(128);

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("AspNetCoreAngular.Entities.Produto", b =>
                {
                    b.HasOne("AspNetCoreAngular.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaID");

                    b.HasOne("AspNetCoreAngular.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorID");
                });
#pragma warning restore 612, 618
        }
    }
}
