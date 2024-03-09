using Microsoft.AspNetCore.Mvc;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Service;
using prova_eclipseworks.Service.Interface;

namespace prova_eclipseworks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        public readonly ITarefaService _tarefaService;
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("{projetoId}")]
        public async Task<ActionResult<Projeto>> GetProjetoPorUsuarioId(int projetoId)
        {
            try
            {
                return Ok(await _tarefaService.GetTarefaPorProjetoId(projetoId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Tarefa>> AdiconarNovaTarefa([FromBody] Tarefa tarefa)
        {
            try
            {
                await _tarefaService.AdiconarNovaTarefa(tarefa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<ActionResult<Tarefa>> EditarNovaTarefa([FromBody] Tarefa tarefa)
        {
            try
            {
                await _tarefaService.EditarNovaTarefa(tarefa);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Tarefa>> DeletarNovaTarefa(int tarefaId)
        {
            try
            {
                await _tarefaService.DeletarNovaTarefa(tarefaId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
