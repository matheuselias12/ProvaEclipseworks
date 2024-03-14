using AutoFixture;
using Moq;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Enums;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository;
using prova_eclipseworks.Repository.Interface;
using prova_eclipseworks.Service;
using Xunit;

namespace TesteUnitarioEclipseworks
{
    public class TarefaTest
    {

        [Fact]
        public void CriaNovoTarefa_AdiconaNoBanco()
        {
            //Arrenge
            var tarefaList = new Fixture().Create<List<Tarefa>>().Take(2).ToList();
            var mockTarefa= new Mock<ITarefaRepository>();
            mockTarefa.Setup(x => x.AdiconarNovaTarefa(tarefaList)).ToString();

            //Act
            TarefaService tarefaService = new(mockTarefa.Object);
            var result = tarefaService.AdiconarNovaTarefa(tarefaList).IsCompleted;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteTarefa_RetornaItemRemovido()
        {
            //Arrenge
            var tarefa = new Fixture().Create<Tarefa>();
            var mockTarefa = new Mock<ITarefaRepository>();
            var tarefaId = tarefa.TarefaId;
            mockTarefa.Setup(x => x.DeletarNovaTarefa(tarefaId));

            //Act
            TarefaService tarefaService = new(mockTarefa.Object);
            var result = tarefaService.DeletarNovaTarefa(tarefaId).IsCompletedSuccessfully;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void EditarTarefa_RetornaItemEditado()
        {
            //Arrenge
            var tarefaList = new Fixture().Create<TarefaDto>();
            var mockTarefa = new Mock<ITarefaRepository>();
            mockTarefa.Setup(x => x.EditarNovaTarefa(tarefaList));

            //Act
            TarefaService tarefaService = new(mockTarefa.Object);
            var result = tarefaService.EditarNovaTarefa(tarefaList).IsCompletedSuccessfully;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async void BuscarTarefaPorProjetoId_RetornaListaComUmItem()
        {
            //Arrenge
            var tarefaList = new Fixture().Create<List<Tarefa>>().Take(2).ToList();
            var mockListProjetos = new Mock<ITarefaRepository>();
            var projetoId = tarefaList.Select(x => x.ProjetoId).FirstOrDefault();
            mockListProjetos.Setup(x => x.GetTarefaPorProjetoId(projetoId)).ReturnsAsync(tarefaList);
            //Act
            TarefaService projetoService = new(mockListProjetos.Object);
            var listProjetos = await projetoService.GetTarefaPorProjetoId(projetoId);
            var result = listProjetos.Where(x => x.ProjetoId == projetoId).ToList().Count();

            //Assert
            Assert.True(result == 1);
        }
    }
}