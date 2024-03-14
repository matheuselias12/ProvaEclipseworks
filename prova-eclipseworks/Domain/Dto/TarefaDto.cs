using prova_eclipseworks.Domain.Enums;

namespace prova_eclipseworks.Domain.Dto
{
    public class TarefaDto
    {
        public int? TarefaId { get; set; }
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusTarefa StatusTarefa { get; set; }
        public Prioridade? Prioridades { get; set; }
    }
}
