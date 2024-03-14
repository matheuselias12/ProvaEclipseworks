using System.ComponentModel.DataAnnotations;

namespace prova_eclipseworks.Domain.Dto
{
    public class HistoricoTarefaDto
    {
        public int TarefaHistoricoId { get; set; }
        public int TarefaId { get; set; }
        public DateTime DataModificacao { get; set; }
        public string? InfoModidicada { get; set; }
        public string? Comentario { get; set; }
    }
}
