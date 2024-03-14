using Microsoft.AspNetCore.Components.Web;

namespace prova_eclipseworks.Domain.Dto
{
    public class ProjetoDto
    {
        public int? ProjetoId { get; set; }
        public int? UsuarioId { get; set; }
        public string? NomeProjeto { get; set; }
        public bool StatusProjeto { get; set; }
    }
}
