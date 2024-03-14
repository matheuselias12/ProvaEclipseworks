using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Repository.Interface
{
    public interface IProjetoRepository
    {
        Task<List<ProjetoDto>> GetProjetoPorUsuarioId(int usuarioId);
        Task AdiconarNovoProjeto(ProjetoDto projeto);
        Task DeletarProjeto(int projetoId);
    }
}
