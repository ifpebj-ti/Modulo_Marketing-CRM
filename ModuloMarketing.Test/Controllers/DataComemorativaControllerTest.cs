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

public class DataComemorativaControllerTest
{


    [Fact]
    public async Task GetDatasComemorativasDoMes_DeveRetornarOkComDatasComemorativas()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<DataComemorativaController>>();
        var mockDataComemorativaRepository = new Mock<IDataComemorativaRepository>();
        var datasComemorativas = new List<DataComemorativa> { new DataComemorativa(), new DataComemorativa() };
        mockDataComemorativaRepository.Setup(repo => repo.GetDatasComemorativasDoMes())
            .ReturnsAsync(datasComemorativas);
        var controller = new DataComemorativaController(mockLogger.Object, mockDataComemorativaRepository.Object);

        // Act
        var result = await controller.GetDatasComemorativasDoMes();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<DataComemorativa>>(okResult.Value);
        Assert.Equal(datasComemorativas, model);
    }

    [Fact]
    public async Task GetDatasComemorativasDoMes_DeveRetornarBadRequestQuandoExcecaoOcorre()
    {
        // Arrange
        var mockLogger = new Mock<ILogger<DataComemorativaController>>();
        var mockDataComemorativaRepository = new Mock<IDataComemorativaRepository>();
        mockDataComemorativaRepository.Setup(repo => repo.GetDatasComemorativasDoMes())
            .ThrowsAsync(new Exception("Erro simulado"));
        var controller = new DataComemorativaController(mockLogger.Object, mockDataComemorativaRepository.Object);

        // Act
        var result = await controller.GetDatasComemorativasDoMes();

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }


}