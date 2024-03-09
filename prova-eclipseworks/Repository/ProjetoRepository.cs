using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Data;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;

namespace prova_eclipseworks.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ProvaEclipseworksDBContext _dBContext;

        public ProjetoRepository(ProvaEclipseworksDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task AdiconarNovoProjeto(Projeto projeto)
        {
            await _dBContext.Projetos.AddAsync(projeto);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<List<Projeto>> GetProjetoPorUsuarioId(int usuarioId)
        {
            return await _dBContext.Projetos.Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }
    }
}
