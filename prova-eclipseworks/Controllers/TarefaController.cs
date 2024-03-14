using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prova_eclipseworks.Domain.Dto;
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

        [HttpPost]
        public async Task<ActionResult<TarefaDto>> AdiconarNovaTarefa([FromBody] List<TarefaDto> tarefa)
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
        [HttpGet("{projetoId}")]
        public async Task<ActionResult<TarefaDto>> GetProjetoPorUsuarioId(int projetoId)
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
        [HttpPut("EditarTarefa")]
        public async Task<ActionResult<TarefaDto>> EditarTarefa([FromBody] TarefaDto tarefa)
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
        public async Task<ActionResult<TarefaDto>> DeletarNovaTarefa(int tarefaId)
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
        [HttpPatch]
        [Authorize(Roles = "GerenteProjeto")]
        [AllowAnonymous]
        public async Task<ActionResult<RelatorioTarefas>> ObterRelatorioDesempenho([FromBody] List<Usuario> usuarios)
        {
            try
            {
                return Ok(await _tarefaService.ObterRelatorioDesempenho(usuarios));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
