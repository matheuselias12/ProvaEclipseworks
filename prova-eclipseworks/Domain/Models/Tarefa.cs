using prova_eclipseworks.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace prova_eclipseworks.Domain.Models
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarefaId { get; set; }
        public int ProjetoId { get; set; }
        public int? UsuarioId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusTarefa StatusTarefa { get; set; }
        public Prioridade Prioridades { get; set; }

        public Projeto Projeto { get; set; }
        //public Usuario Usuario { get; set; }
    }
}
