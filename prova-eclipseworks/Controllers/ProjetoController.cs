using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Projeto>> GetProjetoPorUsuarioId(int usuarioId)
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
        public async Task<ActionResult<Projeto>> GetProjetoPorUsuarioId([FromBody] Projeto projeto)
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
    }
}
