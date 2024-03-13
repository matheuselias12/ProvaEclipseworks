using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Repository.Interface
{
    public interface IProjetoRepository
    {
        Task<List<Projeto>> GetProjetoPorUsuarioId(int usuarioId);
        Task AdiconarNovoProjeto(Projeto projeto);
        Task DeletarProjeto(int projetoId);
    }
}
