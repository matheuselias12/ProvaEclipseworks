using Microsoft.EntityFrameworkCore;
using prova_eclipseworks.Data;
using prova_eclipseworks.Domain.Enums;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;
using System.Linq;

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
        public async Task DeletarProjeto(int projetoId)
        {
            var tarefas = _dBContext.Tarefas.Where(x => x.ProjetoId == projetoId).ToList();

            var projeto = await _dBContext.Projetos.Where(x => x.ProjetoId == projetoId).FirstOrDefaultAsync();

            if (tarefas.Select(x => x.StatusTarefa).Contains(StatusTarefa.Pendente) || tarefas.Select(x => x.StatusTarefa).Contains(StatusTarefa.EmAndamento))
            {
                throw new Exception($"O projeto com id {projeto.NomeProjeto} não foi possivel excluir, pois existe tarefas pendentes ou em andamento a este projeto.");
            }
            else
            {
                _dBContext.Projetos.Remove(projeto);
                await _dBContext.SaveChangesAsync();
            }
        }
    }
}
