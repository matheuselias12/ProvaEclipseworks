using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using prova_eclipseworks.Data;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Enums;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;
using System.Linq;

namespace prova_eclipseworks.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ProvaEclipseworksDBContext _dBContext;
        private readonly IMapper _mapper;

        public ProjetoRepository(ProvaEclipseworksDBContext dBContext, IMapper mapper)
        {
            _dBContext = dBContext;
            _mapper = mapper;
        }

        public async Task AdiconarNovoProjeto(ProjetoDto projetoDto)
        {
            var projeto = _mapper.Map<Projeto>(projetoDto);
            await _dBContext.Projetos.AddAsync(projeto);
            _dBContext.SaveChanges();
        }

        public async Task<List<ProjetoDto>> GetProjetoPorUsuarioId(int usuarioId)
        {
            var projetos = await _dBContext.Projetos.Where(x => x.UsuarioId == usuarioId).ToListAsync();
            return _mapper.Map<List<ProjetoDto>>(projetos);
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
