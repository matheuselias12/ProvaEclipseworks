using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Repository.Interface
{
    public interface ITarefaRepository
    {
        Task<List<TarefaDto>> GetTarefaPorProjetoId(int projetoId);
        Task AdiconarNovaTarefa(List<TarefaDto> tarefa);
        Task EditarNovaTarefa(TarefaDto tarefa);
        Task DeletarNovaTarefa(int tarefaId);
        Task<List<TarefaDto>> ObterRelatorioDesempenho(int usuarioId);
    }
}
