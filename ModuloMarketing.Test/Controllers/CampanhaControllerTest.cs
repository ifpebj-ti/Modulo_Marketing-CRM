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
using ModuloMarketing.Api.DTOs;

public class CampanhaControllerTest
{
    [Fact]
    public async Task Get_DeveRetornarOkComListaDeCampanhas()
    {
        // Arrange
        var pageNumber = 1;
        var itemNumber = 10;
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhas = new List<Campanha> { new Campanha(), new Campanha() };
        mockCampanhaRepository.Setup(repo => repo.GetTodasASCampanhas(pageNumber, itemNumber))
            .ReturnsAsync(campanhas);
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.Get(pageNumber, itemNumber);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Campanha>>(okResult.Value);
        Assert.Equal(campanhas, model);
    }

    [Fact]
    public async Task Get_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var pageNumber = 1;
        var itemNumber = 10;
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        mockCampanhaRepository.Setup(repo => repo.GetTodasASCampanhas(pageNumber, itemNumber))
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.Get(pageNumber, itemNumber);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }


    [Fact]
    public async Task GetCampanhasAtivas_DeveRetornarOkComListaDeCampanhasAtivas()
    {
        // Arrange
        var pageNumber = 1;
        var itemNumber = 10;
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhasAtivas = new List<Campanha> { new Campanha(), new Campanha() };
        mockCampanhaRepository.Setup(repo => repo.GetCampanhasAtivas(pageNumber, itemNumber))
            .ReturnsAsync(campanhasAtivas);
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.GetCampanhasAtivas(pageNumber, itemNumber);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<Campanha>>(okResult.Value);
        Assert.Equal(campanhasAtivas, model);
    }

    [Fact]
    public async Task GetCampanhasAtivas_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var pageNumber = 1;
        var itemNumber = 10;
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        mockCampanhaRepository.Setup(repo => repo.GetCampanhasAtivas(pageNumber, itemNumber))
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.GetCampanhasAtivas(pageNumber, itemNumber);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }



    [Fact]
    public async Task Post_DeveRetornarCreatedAtActionComCampanhaCriada()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaRequest = new CampanhaRequest
        (
            "Nome da campanha",
            "Nome do criador",
            "Email do criador",
            "Descrição",
            DateTime.Now,
            DateTime.Now,
            DateTime.Now,
            "Mensagem",
            "Observãção",
            100.0,
            true,
            0,
            0,
            0,
            0
        );
        var campanhaCriada = new Campanha { /* preencha com os dados da campanha criada */ };

        mockCampanhaRepository.Setup(repo => repo.SalvarCampanha(campanhaRequest))
            .ReturnsAsync(campanhaCriada);

        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.Post(campanhaRequest);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(CampanhaController.GetById), createdAtActionResult.ActionName);
        Assert.Equal(campanhaCriada.Id_Campanha, createdAtActionResult.RouteValues["id"]);
        Assert.Same(campanhaCriada, createdAtActionResult.Value);
    }

    [Fact]
    public async Task Post_DeveRetornarBadRequestQuandoModelInvalido()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaRequest = new CampanhaRequest
        (
            "Nome da campanha",
            "Nome do criador",
            "Email do criador",
            "Descrição",
            DateTime.Now,
            DateTime.Now,
            DateTime.Now,
            "Mensagem",
            "Observãção",
            100.0,
            true,
            0,
            0,
            0,
            0
        );

        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);
        controller.ModelState.AddModelError("CampoRequerido", "O campo é obrigatório");

        // Act
        var result = await controller.Post(campanhaRequest);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Post_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaRequest = new CampanhaRequest
        (
            "Nome da campanha",
            "Nome do criador",
            "Email do criador",
            "Descrição",
            DateTime.Now,
            DateTime.Now,
            DateTime.Now,
            "Mensagem",
            "Observãção",
            100.0,
            true,
            0,
            0,
            0,
            0
        );
        mockCampanhaRepository.Setup(repo => repo.SalvarCampanha(campanhaRequest))
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.Post(campanhaRequest);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }



    [Fact]
    public async Task DesativarCampanha_DeveRetornarOkQuandoCampanhaDesativada()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaId = 1; // ID da campanha a ser desativada

        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.DesativarCampanha(campanhaId);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DesativarCampanha_DeveRetornarBadRequestQuandoModelInvalido()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaId = 1; // ID da campanha a ser desativada
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);
        controller.ModelState.AddModelError("CampoRequerido", "O campo é obrigatório");

        // Act
        var result = await controller.DesativarCampanha(campanhaId);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task DesativarCampanha_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaId = 1; // ID da campanha a ser desativada
        mockCampanhaRepository.Setup(repo => repo.DesativarCampanha(campanhaId))
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.DesativarCampanha(campanhaId);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }


    [Fact]
    public async Task GetById_DeveRetornarOkComCampanhaPorId()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaId = 1; // ID da campanha a ser buscada
        var campanhaEncontrada = new Campanha { /* preencha com os dados da campanha encontrada */ };

        mockCampanhaRepository.Setup(repo => repo.GetCampanhaPorId(campanhaId))
            .ReturnsAsync(campanhaEncontrada);
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.GetById(campanhaId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsType<Campanha>(okResult.Value);
        Assert.Same(campanhaEncontrada, model);
    }

    [Fact]
    public async Task GetById_DeveRetornarNotFoundQuandoCampanhaNaoEncontrada()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaId = 1; // ID da campanha a ser buscada
        mockCampanhaRepository.SetupSequence(repo => repo.GetCampanhaPorId(It.IsAny<int>()))
            .Returns(Task.FromResult<Campanha>(null)) // ou o valor apropriado
            .Returns(Task.FromResult(new Campanha { /* preencha com os dados da campanha */ }));
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.GetById(campanhaId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetById_DeveRetornarBadRequestQuandoModelInvalido()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaId = 1; // ID da campanha a ser buscada
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);
        controller.ModelState.AddModelError("CampoRequerido", "O campo é obrigatório");

        // Act
        var result = await controller.GetById(campanhaId);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task GetById_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<CampanhaController>>();
        var mockCampanhaRepository = new Mock<ICampanhaRepository>();
        var campanhaId = 1; // ID da campanha a ser buscada
        mockCampanhaRepository.Setup(repo => repo.GetCampanhaPorId(campanhaId))
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new CampanhaController(mockLogger.Object, mockCampanhaRepository.Object);

        // Act
        var result = await controller.GetById(campanhaId);

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }


}
