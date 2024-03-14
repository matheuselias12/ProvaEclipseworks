using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;
using prova_eclipseworks.Service.Interface;

namespace prova_eclipseworks.Service
{
    public class ProjetoService : IProjetoService
    {
        public readonly IProjetoRepository _projetoRepository;
        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public async Task AdiconarNovoProjeto(ProjetoDto projeto)
        {
           await _projetoRepository.AdiconarNovoProjeto(projeto);
        }

        public async Task<List<ProjetoDto>> GetProjetoPorUsuarioId(int usuarioId)
        {
            return await _projetoRepository.GetProjetoPorUsuarioId(usuarioId);
        }
        public async Task DeletarProjeto(int projetoId)
        {
            await _projetoRepository.DeletarProjeto(projetoId);
        }
    }
}
