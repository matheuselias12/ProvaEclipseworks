using prova_eclipseworks.Domain.Enums;

namespace prova_eclipseworks.Domain.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public int ProjetoId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusTarefa StatusTarefa { get; set; }
    }
}
