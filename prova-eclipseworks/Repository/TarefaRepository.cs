using AutoMapper;
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
        private readonly IMapper _mapper;

        public TarefaRepository(ProvaEclipseworksDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }
        public async Task<List<TarefaDto>> GetTarefaPorProjetoId(int projetoId)
        {
            return _mapper.Map<List<TarefaDto>>(await _dBContext.Tarefas.Where(x => x.ProjetoId == projetoId).ToListAsync());
        }
        public async Task<List<TarefaDto>> ObterRelatorioDesempenho(int usuarioId)
        {
            return _mapper.Map<List<TarefaDto>>(await _dBContext.Tarefas.Where(x => x.DataVencimento >= DateTime.Today.AddDays(-30) && x.UsuarioId == usuarioId).ToListAsync());
        }
        public async Task AdiconarNovaTarefa(List<TarefaDto> tarefas)
        {
            var listTarefas = new List<TarefaDto>();
            foreach (var item in tarefas)
            {
                var obj = _dBContext.Tarefas.Where(x => x.ProjetoId == item.ProjetoId).ToList();

                if (obj.Count() == 20) 
                    throw new Exception($"Esse projeto excedeu o numero de tarefas.");

                listTarefas.Add(item);
            }
            var tarefasMap = _mapper.Map<List<Tarefa>>(listTarefas);
            await _dBContext.Tarefas.AddRangeAsync(tarefasMap);
            _dBContext.SaveChanges();
            return;
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
