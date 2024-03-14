using AutoFixture;
using Moq;
using prova_eclipseworks.Controllers;
using prova_eclipseworks.Domain.Dto;
using prova_eclipseworks.Domain.Models;
using prova_eclipseworks.Repository.Interface;
using prova_eclipseworks.Service;

namespace TesteUnitarioEclipseworks
{
    public class ProjetoTest
    {
        [Fact]
        public async void BuscarProjetoPorUsuarioId_RetornaListaComUmItem()
        {
            //Arrenge
            var listProjeto = new List<ProjetoDto>();
            var projeto1 = new ProjetoDto()
            {
                ProjetoId = 1,
                UsuarioId = 1,
                NomeProjeto = "Teste 1",
                StatusProjeto = true
            };
            var projeto2 = new ProjetoDto()
            {
                ProjetoId = 1,
                UsuarioId = 2,
                NomeProjeto = "Teste 2",
                StatusProjeto = true
            };

            listProjeto.Add(projeto1);
            listProjeto.Add(projeto2);

            var usuarioId = 1;
            var mockListProjetos = new Mock<IProjetoRepository>();
            mockListProjetos.Setup(x => x.GetProjetoPorUsuarioId(usuarioId)).ReturnsAsync(listProjeto);

            //Act
            ProjetoService projetoService = new(mockListProjetos.Object);
            var listProjetos = await projetoService.GetProjetoPorUsuarioId(usuarioId);
            var result = listProjetos.Where(x => x.UsuarioId == usuarioId).Count() == 1;

            //Assert
            Assert.True(result);
        }
        [Fact]
        public async void BuscarProjetoPorUsuarioId_RetornaListaComTresItems()
        {
            //Arrenge
            var listUsuario = new List<ProjetoDto>();
            var usuario1 = new ProjetoDto()
            {
                ProjetoId = 1,
                UsuarioId = 1,
                NomeProjeto = "Teste 1",
                StatusProjeto = true
            };
            var usuario2 = new ProjetoDto()
            {
                ProjetoId = 1,
                UsuarioId = 2,
                NomeProjeto = "Teste 2",
                StatusProjeto = true
            };

            listUsuario.Add(usuario1);
            listUsuario.Add(usuario2);

            var usuarioId = 1;
            var mockListProjetos = new Mock<IProjetoRepository>();
            mockListProjetos.Setup(x => x.GetProjetoPorUsuarioId(usuarioId)).ReturnsAsync(listUsuario);

            //Act
            ProjetoService projetoService = new(mockListProjetos.Object);
            var listProjetos = await projetoService.GetProjetoPorUsuarioId(usuarioId);
            var result = listProjetos.Where(x => x.UsuarioId == usuarioId).Count() == 3;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void CriaNovoProjeto_RetornaSeFoiAdiconado()
        {
            //Arrenge
            var projeto = new Fixture().Create<ProjetoDto>();
            var mockListProjetos = new Mock<IProjetoRepository>();

            mockListProjetos.Setup(x => x.AdiconarNovoProjeto(projeto));

            //Act
            ProjetoService projetoService = new(mockListProjetos.Object);
            var result = projetoService.AdiconarNovoProjeto(projeto).IsCompletedSuccessfully;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DeleteProjeto_RetornaItemRemovido()
        {
            //Arrenge
            var usuario = new Fixture().Create<Projeto>();
            var mockListProjetos = new Mock<IProjetoRepository>();
            var projetoId = usuario.ProjetoId;

            mockListProjetos.Setup(x => x.DeletarProjeto(projetoId));

            //Act
            ProjetoService projetoService = new(mockListProjetos.Object);
            var result = projetoService.DeletarProjeto(projetoId).IsCompletedSuccessfully;

            //Assert
            Assert.True(result);
        }
    }
}