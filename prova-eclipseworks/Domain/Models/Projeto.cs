using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prova_eclipseworks.Domain.Models
{
    public class Projeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjetoId { get; set; }
        public int? UsuarioId { get; set; }
        public string? NomeProjeto { get; set; }
        public bool StatusProjeto { get; set; }

        //public Usuario? Usuario { get; set; }
    }
}
