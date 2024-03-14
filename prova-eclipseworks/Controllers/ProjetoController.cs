using Microsoft.AspNetCore.Mvc;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Service.Interface;

namespace prova_eclipseworks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjetoController : ControllerBase
    {
        public readonly IProjetoService _projetoService;
        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<List<ProjetoDto>>> GetProjetoPorUsuarioId(int usuarioId)
        {
            try
            {
                return Ok(await _projetoService.GetProjetoPorUsuarioId(usuarioId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProjetoDto>> GetProjetoPorUsuarioId([FromBody] ProjetoDto projeto)
        {
            try
            {
                await _projetoService.AdiconarNovoProjeto(projeto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult<Projeto>> DeletarProjeto(int projetoId)
        {
            try
            {
                await _projetoService.DeletarProjeto(projetoId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
