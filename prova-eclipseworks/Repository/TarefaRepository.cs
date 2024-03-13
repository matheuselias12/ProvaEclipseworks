using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Data;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Enums;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;
using System.Collections.Immutable;

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
        public async Task<List<Tarefa>> ObterRelatorioDesempenho(int usuarioId)
        {
            return await _dBContext.Tarefas.Where(x => x.DataVencimento >= DateTime.Today.AddDays(-30) && x.UsuarioId == usuarioId).ToListAsync();
        }
        public async Task AdiconarNovaTarefa(List<Tarefa> tarefa)
        {
            foreach (var item in tarefa)
            {
                var obj = _dBContext.Tarefas.Where(x => x.ProjetoId == item.ProjetoId).ToList();

                if (obj.Count() == 20) 
                    throw new Exception($"Esse projeto excedeu o numero de tarefas.");

                await _dBContext.Tarefas.AddAsync(item);
                await _dBContext.SaveChangesAsync();
            }
        }
        public async Task EditarNovaTarefa(TarefaDto tarefa)
        {
            var tarefaObj = _dBContext.Tarefas.Where(x => x.TarefaId == tarefa.TarefaId).FirstOrDefault();

            await HistoricoTarefas(tarefa);
            if (tarefaObj is null)
                throw new Exception($"A tarefa com id {tarefa.TarefaId} não foi encontrada no banco de dados.");

            tarefaObj.StatusTarefa = tarefa.StatusTarefa;
            tarefaObj.Descricao = tarefa.Descricao;
            tarefaObj.Titulo = tarefa.Titulo;


            _dBContext.Tarefas.Update(tarefaObj);
            await _dBContext.SaveChangesAsync();

            return;
        }
        private async Task HistoricoTarefas(TarefaDto tarefaDto)
        {
            var tarefaObj = _dBContext.Tarefas.Where(x => x.TarefaId == tarefaDto.TarefaId).FirstOrDefault();

            var historicoTarefa = new HistoricoTarefa() 
            {
                TarefaId = tarefaObj.TarefaId,
                DataModificacao = DateTime.Today,
                InfoModidicada = $"{tarefaObj.TarefaId}, {tarefaObj.ProjetoId}, {tarefaObj.UsuarioId}, {tarefaObj.Titulo}, {tarefaObj.Descricao}, {tarefaObj.DataVencimento}, {tarefaObj.StatusTarefa}, {tarefaObj.Prioridades}",
                Comentario = tarefaDto.Comentario,
             };

            _dBContext.HistoricoTarefas.Add(historicoTarefa);
            await _dBContext.SaveChangesAsync();
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
