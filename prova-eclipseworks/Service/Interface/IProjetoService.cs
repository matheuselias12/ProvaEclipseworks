using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Service.Interface
{
    public interface IProjetoService
    {
        Task<List<Projeto>> GetProjetoPorUsuarioId(int usuarioId);
        Task AdiconarNovoProjeto(Projeto projeto);
        Task DeletarProjeto(int projetoId);
    }
}
