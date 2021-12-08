﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Napista.Data;

namespace Napista.Migrations
{
    [DbContext(typeof(ApiDbConteudo))]
    [Migration("20211208013344_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Napista.Models.Cartao", b =>
                {
                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bandeira")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cvv")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_expedicao")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PagamentoId_Pagamento")
                        .HasColumnType("int");

                    b.Property<string>("Titular")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Numero");

                    b.HasIndex("PagamentoId_Pagamento");

                    b.ToTable("Cartao");
                });

            modelBuilder.Entity("Napista.Models.Compras", b =>
                {
                    b.Property<int>("Id_Compra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CartaoNumero")
                        .HasColumnType("int");

                    b.Property<int>("Qtde_comprada")
                        .HasColumnType("int");

                    b.HasKey("Id_Compra");

                    b.HasIndex("CartaoNumero");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Napista.Models.Pagamento", b =>
                {
                    b.Property<int>("Id_Pagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ComprasId_Compra")
                        .HasColumnType("int");

                    b.HasKey("Id_Pagamento");

                    b.HasIndex("ComprasId_Compra");

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("Napista.Models.Produtos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ComprasId_Compra")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qtde_estoque")
                        .HasColumnType("int");

                    b.Property<float>("Valor_unitario")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ComprasId_Compra");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Napista.Models.Cartao", b =>
                {
                    b.HasOne("Napista.Models.Pagamento", null)
                        .WithMany("Cartoes")
                        .HasForeignKey("PagamentoId_Pagamento");
                });

            modelBuilder.Entity("Napista.Models.Compras", b =>
                {
                    b.HasOne("Napista.Models.Cartao", "Cartao")
                        .WithMany()
                        .HasForeignKey("CartaoNumero");

                    b.Navigation("Cartao");
                });

            modelBuilder.Entity("Napista.Models.Pagamento", b =>
                {
                    b.HasOne("Napista.Models.Compras", null)
                        .WithMany("Pagamentos")
                        .HasForeignKey("ComprasId_Compra");
                });

            modelBuilder.Entity("Napista.Models.Produtos", b =>
                {
                    b.HasOne("Napista.Models.Compras", null)
                        .WithMany("Produto")
                        .HasForeignKey("ComprasId_Compra");
                });

            modelBuilder.Entity("Napista.Models.Compras", b =>
                {
                    b.Navigation("Pagamentos");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Napista.Models.Pagamento", b =>
                {
                    b.Navigation("Cartoes");
                });
#pragma warning restore 612, 618
        }
    }
}