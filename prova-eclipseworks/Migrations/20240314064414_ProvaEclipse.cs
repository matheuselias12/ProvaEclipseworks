﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prova_eclipseworks.Migrations
{
    /// <inheritdoc />
    public partial class ProvaEclipse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    NomeProjeto = table.Column<string>(type: "varchar(500)", nullable: true),
                    StatusProjeto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.ProjetoId);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    TarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: true),
                    DataVencimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusTarefa = table.Column<int>(type: "int", nullable: false),
                    Prioridades = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.TarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "ProjetoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoTarefa",
                columns: table => new
                {
                    TarefaHistoricoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarefaId = table.Column<int>(type: "int", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    InfoModidicada = table.Column<string>(type: "varchar(800)", nullable: true),
                    Comentario = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoTarefa", x => x.TarefaHistoricoId);
                    table.ForeignKey(
                        name: "FK_HistoricoTarefa_Tarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefa",
                        principalColumn: "TarefaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoTarefa_TarefaId",
                table: "HistoricoTarefa",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ProjetoId",
                table: "Tarefa",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoTarefa");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
