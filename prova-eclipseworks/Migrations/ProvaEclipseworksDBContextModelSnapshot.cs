﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prova_eclipseworks.Data;

#nullable disable

namespace prova_eclipseworks.Migrations
{
    [DbContext(typeof(ProvaEclipseworksDBContext))]
    partial class ProvaEclipseworksDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("prova_eclipseworks.Domain.Models.HistoricoTarefa", b =>
                {
                    b.Property<int>("TarefaHistoricoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarefaHistoricoId"));

                    b.Property<string>("Comentario")
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime");

                    b.Property<string>("InfoModidicada")
                        .HasColumnType("varchar(800)");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.HasKey("TarefaHistoricoId");

                    b.HasIndex("TarefaId");

                    b.ToTable("HistoricoTarefa", (string)null);
                });

            modelBuilder.Entity("prova_eclipseworks.Domain.Models.Projeto", b =>
                {
                    b.Property<int>("ProjetoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjetoId"));

                    b.Property<string>("NomeProjeto")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("StatusProjeto")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ProjetoId");

                    b.ToTable("Projeto", (string)null);
                });

            modelBuilder.Entity("prova_eclipseworks.Domain.Models.Tarefa", b =>
                {
                    b.Property<int>("TarefaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarefaId"));

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Prioridades")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int>("StatusTarefa")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("TarefaId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Tarefa", (string)null);
                });

            modelBuilder.Entity("prova_eclipseworks.Domain.Models.HistoricoTarefa", b =>
                {
                    b.HasOne("prova_eclipseworks.Domain.Models.Tarefa", "Tarefa")
                        .WithMany()
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("prova_eclipseworks.Domain.Models.Tarefa", b =>
                {
                    b.HasOne("prova_eclipseworks.Domain.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });
#pragma warning restore 612, 618
        }
    }
}
