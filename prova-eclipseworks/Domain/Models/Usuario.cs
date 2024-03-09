namespace prova_eclipseworks.Domain.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public required string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
    }
}
