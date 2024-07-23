using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BackendLeads.Controllers;
using BackendLeads.Services.Interface;
using BackendLeads.DTO;
using BackendLeads.Utils;
using System.Threading.Tasks;

public class GestorControllerTests
{
    private readonly Mock<IGestorService> _mockGestorService;
    private readonly GestorController _controller;

    public GestorControllerTests()
    {
        _mockGestorService = new Mock<IGestorService>();
        _controller = new GestorController(_mockGestorService.Object);
    }

    [Fact]
    public async Task Cadastrar_ReturnsRespostaPadrao()
    {
        // Arrange
        var gestorDto = new GestorDto { /* Inicialize as propriedades conforme necessário */ };
        var respostaEsperada = new RespostaPadrao { /* Inicialize as propriedades conforme necessário */ };
        _mockGestorService.Setup(service => service.AdicionarGestor(gestorDto)).ReturnsAsync(respostaEsperada);

        // Act
        var result = await _controller.Cadastrar(gestorDto);

        // Assert
        Assert.Equal(respostaEsperada, result);
    }
}
