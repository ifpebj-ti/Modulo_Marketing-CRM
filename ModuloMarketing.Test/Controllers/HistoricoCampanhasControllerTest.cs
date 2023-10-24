using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ModuloMarketing.Api.Controllers;
using ModuloMarketing.Api.Domain;
using ModuloMarketing.Api.Repository.Implementation;
using ModuloMarketing.Api.Repository.Interfaces;

public class HistoricoCampanhasControllerTest
{


    [Fact]
    public async Task Get_DeveRetornarOkComHistoricoCampanhas()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HistoricoCampanhasController>>();
        var mockHistoricoCampanhasRepository = new Mock<IHistoricoCampanhasRepository>();
        var historicoCampanhas = new List<HistoricoCampanhas> { new HistoricoCampanhas(), new HistoricoCampanhas() };
        mockHistoricoCampanhasRepository.Setup(repo => repo.GetHistorico())
            .ReturnsAsync(historicoCampanhas);
        var controller = new HistoricoCampanhasController(mockLogger.Object, mockHistoricoCampanhasRepository.Object);

        // Act
        var result = await controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<HistoricoCampanhas>>(okResult.Value);
        Assert.Equal(historicoCampanhas, model);
    }

    [Fact]
    public async Task Get_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HistoricoCampanhasController>>();
        var mockHistoricoCampanhasRepository = new Mock<IHistoricoCampanhasRepository>();
        mockHistoricoCampanhasRepository.Setup(repo => repo.GetHistorico())
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new HistoricoCampanhasController(mockLogger.Object, mockHistoricoCampanhasRepository.Object);

        // Act
        var result = await controller.Get();

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }


    [Fact]
    public async Task GetById_DeveRetornarOkComHistoricoPorId()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HistoricoCampanhasController>>();
        var mockHistoricoCampanhasRepository = new Mock<IHistoricoCampanhasRepository>();
        var historicoId = 1; // ID do histórico a ser buscado
        var historicoEncontrado = new HistoricoCampanhas { /* preencha com os dados do histórico encontrado */ };

        mockHistoricoCampanhasRepository.Setup(repo => repo.GetHistoricoPorId(historicoId))
            .ReturnsAsync(historicoEncontrado);
        var controller = new HistoricoCampanhasController(mockLogger.Object, mockHistoricoCampanhasRepository.Object);

        // Act
        var result = await controller.GetById(historicoId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsType<HistoricoCampanhas>(okResult.Value);
        Assert.Same(historicoEncontrado, model);
    }

    [Fact]
    public async Task GetById_DeveRetornarNotFoundQuandoHistoricoNaoEncontrado()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HistoricoCampanhasController>>();
        var mockHistoricoCampanhasRepository = new Mock<IHistoricoCampanhasRepository>();
        var historicoId = 1; // ID do histórico a ser buscado
        mockHistoricoCampanhasRepository.SetupSequence(repo => repo.GetHistoricoPorId(It.IsAny<int>()))
            .Returns(Task.FromResult<HistoricoCampanhas>(null))
            .Returns(Task.FromResult(new HistoricoCampanhas { }));
        var controller = new HistoricoCampanhasController(mockLogger.Object, mockHistoricoCampanhasRepository.Object);

        // Act
        var result = await controller.GetById(historicoId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetById_DeveRetornarBadRequestQuandoModelInvalido()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HistoricoCampanhasController>>();
        var mockHistoricoCampanhasRepository = new Mock<IHistoricoCampanhasRepository>();
        var historicoId = 1; // ID do histórico a ser buscado
        var controller = new HistoricoCampanhasController(mockLogger.Object, mockHistoricoCampanhasRepository.Object);
        controller.ModelState.AddModelError("CampoRequerido", "O campo é obrigatório");

        // Act
        var result = await controller.GetById(historicoId);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetById_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<HistoricoCampanhasController>>();
        var mockHistoricoCampanhasRepository = new Mock<IHistoricoCampanhasRepository>();
        var historicoId = 1; // ID do histórico a ser buscado
        mockHistoricoCampanhasRepository.Setup(repo => repo.GetHistoricoPorId(historicoId))
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new HistoricoCampanhasController(mockLogger.Object, mockHistoricoCampanhasRepository.Object);

        // Act
        var result = await controller.GetById(historicoId);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }


}