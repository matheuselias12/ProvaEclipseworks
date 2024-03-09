using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Data;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;

namespace prova_eclipseworks.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ProvaEclipseworksDBContext _dBContext;

        public TarefaRepository(ProvaEclipseworksDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task<List<Tarefa>> GetTarefaPorProjetoId(int projetoId)
        {
            return await _dBContext.Tarefas.Where(x => x.ProjetoId == projetoId).ToListAsync();
        }

        public async Task AdiconarNovaTarefa(Tarefa tarefa)
        {
            await _dBContext.Tarefas.AddAsync(tarefa);
            await _dBContext.SaveChangesAsync();
        }
        public async Task EditarNovaTarefa(Tarefa tarefa)
        {
            var tarefaObj = _dBContext.Tarefas.Where(x => x.TarefaId == tarefa.TarefaId).FirstOrDefault();

            if (tarefaObj is null)
                throw new Exception($"A tarefa com id {tarefa.TarefaId} não foi encontrada no banco de dados.");

            tarefaObj.StatusTarefa = tarefa.StatusTarefa;
            tarefaObj.Descricao = tarefa.Descricao;

            _dBContext.Tarefas.Update(tarefaObj);
            await _dBContext.SaveChangesAsync();
            return;
        }

        public async Task DeletarNovaTarefa(int tarefaId)
        {
            var tarefa = _dBContext.Tarefas.Where(x => x.TarefaId == tarefaId).FirstOrDefault();

            if (tarefa is null)
                throw new Exception($"A tarefa com id {tarefaId} não foi encontrada no banco de dados.");

            _dBContext.Tarefas.Remove(tarefa);
            await _dBContext.SaveChangesAsync();
            return;
        }
    }
}
