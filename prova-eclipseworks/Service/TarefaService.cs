using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;
using prova_eclipseworks.Service.Interface;

namespace prova_eclipseworks.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task AdiconarNovaTarefa(Tarefa tarefa)
        {
           await _tarefaRepository.AdiconarNovaTarefa(tarefa);
        }
        public async Task DeletarNovaTarefa(int tarefaId)
        {
            await _tarefaRepository.DeletarNovaTarefa(tarefaId);
        }
        public async Task EditarNovaTarefa(Tarefa tarefa)
        {
            await _tarefaRepository.EditarNovaTarefa(tarefa);
        }
        public async Task<List<Tarefa>> GetTarefaPorProjetoId(int projetoId)
        {
            return await _tarefaRepository.GetTarefaPorProjetoId(projetoId);
        }
    }
}
