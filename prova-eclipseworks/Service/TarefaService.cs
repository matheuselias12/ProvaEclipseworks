using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Enums;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository;
using prova_eclipseworks.Repository.Interface;
using prova_eclipseworks.Service.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace prova_eclipseworks.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task AdiconarNovaTarefa(List<TarefaDto> tarefa)
        {
            await _tarefaRepository.AdiconarNovaTarefa(tarefa);
        }
        public async Task DeletarNovaTarefa(int tarefaId)
        {
            await _tarefaRepository.DeletarNovaTarefa(tarefaId);
        }
        public async Task EditarNovaTarefa(TarefaDto tarefa)
        {
            await _tarefaRepository.EditarNovaTarefa(tarefa);
        }
        public async Task<List<TarefaDto>> GetTarefaPorProjetoId(int projetoId)
        {
            return await _tarefaRepository.GetTarefaPorProjetoId(projetoId);
        }
        public async Task<List<RelatorioTarefas>> ObterRelatorioDesempenho(List<Usuario> usuarios)
        {
            var listRelatorioTarefas = new List<RelatorioTarefas>();

            foreach (var item in usuarios)
            {
                var listTarefa = await _tarefaRepository.ObterRelatorioDesempenho(item.UsuarioId);
                var quatidadeConcluida = listTarefa.Where(x => x.StatusTarefa == StatusTarefa.Concluida).Count();
                var totalAtividades = listTarefa.Count();
                decimal percentual = (Convert.ToDecimal(quatidadeConcluida) / Convert.ToDecimal(totalAtividades)) * 100;
                var obj = new RelatorioTarefas()
                {
                    UsuarioId = item.UsuarioId,
                    Percentual = percentual
                };
                listRelatorioTarefas.Add(obj);
            }
            return listRelatorioTarefas;
        }
    }
}
