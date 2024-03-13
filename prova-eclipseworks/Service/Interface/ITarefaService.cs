﻿using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Service.Interface
{
    public interface ITarefaService
    {
        Task<List<Tarefa>> GetTarefaPorProjetoId(int projetoId);
        Task AdiconarNovaTarefa(List<Tarefa> tarefa);
        Task EditarNovaTarefa(TarefaDto tarefa);
        Task DeletarNovaTarefa(int tarefaId);
        Task<List<RelatorioTarefas>> ObterRelatorioDesempenho(List<Usuario> usuarios);
    }
}
