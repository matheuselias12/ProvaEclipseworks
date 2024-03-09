using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Service.Interface
{
    public interface ITarefaService
    {
        Task<List<Tarefa>> GetTarefaPorProjetoId(int projetoId);
        Task AdiconarNovaTarefa(Tarefa tarefa);
        Task EditarNovaTarefa(Tarefa tarefa);
        Task DeletarNovaTarefa(int tarefaId);
    }
}
