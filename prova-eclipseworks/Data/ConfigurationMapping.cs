using AutoMapper;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;

namespace prova_eclipseworks.Data
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Projeto, ProjetoDto>().ReverseMap();
            CreateMap<HistoricoTarefa, HistoricoTarefaDto>().ReverseMap();
            CreateMap<Tarefa, TarefaDto>().ReverseMap();
        }
    }
}
