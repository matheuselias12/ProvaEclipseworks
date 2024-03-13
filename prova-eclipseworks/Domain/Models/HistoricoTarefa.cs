using System.ComponentModel.DataAnnotations;

namespace prova_eclipseworks.Domain.Models
{
    public class HistoricoTarefa
    {
        [Key]
        public int TarefaHistoricoId { get; set; }
        public int TarefaId { get; set; }
        public DateTime DataModificacao { get; set; }
        public string? InfoModidicada { get; set; }
        public string? Comentario { get; set; }
    }
}
