using Microsoft.AspNetCore.Components.Web;

namespace prova_eclipseworks.Domain.Models
{
    public class Projeto
    {
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
        public string? NomeProjeto { get; set; }
        public bool StatusProjeto { get; set; }

        public Usuario Usuario { get; set; }
    }
}
