using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BackendLeads.Controllers;
using BackendLeads.Service.Interface;
using BackendLeads.DTO;
using BackendLeads.Utils;
using System.Threading.Tasks;

public class AutenticacaoControllerTests
{
    private readonly Mock<IAutenticacaoService> _mockAutenticacaoService;
    private readonly AutenticacaoController _controller;

    public AutenticacaoControllerTests()
    {
        _mockAutenticacaoService = new Mock<IAutenticacaoService>();
        _controller = new AutenticacaoController(_mockAutenticacaoService.Object);
    }

    [Fact]
    public async Task RegistrarAdmin_ReturnsRespostaPadrao()
    {
        // Arrange
        var cadastrarUsuarioDto = new CadastrarUsuarioDto { /* Inicialize as propriedades conforme necessário */ };
        var respostaEsperada = new RespostaPadrao { /* Inicialize as propriedades conforme necessário */ };
        _mockAutenticacaoService.Setup(service => service.RegistrarAdmin(cadastrarUsuarioDto)).ReturnsAsync(respostaEsperada);

        // Act
        var result = await _controller.RegistrarAdmin(cadastrarUsuarioDto);

        // Assert
        Assert.Equal(respostaEsperada, result);
    }

    [Fact]
    public async Task RegistrarLeads_ReturnsRespostaPadrao()
    {
        // Arrange
        var cadastrarUsuarioDto = new CadastrarUsuarioDto { /* Inicialize as propriedades conforme necessário */ };
        var respostaEsperada = new RespostaPadrao { /* Inicialize as propriedades conforme necessário */ };
        _mockAutenticacaoService.Setup(service => service.RegistrarLeads(cadastrarUsuarioDto)).ReturnsAsync(respostaEsperada);

        // Act
        var result = await _controller.RegistrarLeads(cadastrarUsuarioDto);

        // Assert
        Assert.Equal(respostaEsperada, result);
    }

    [Fact]
    public async Task Login_ReturnsRespostaPadrao()
    {
        // Arrange
        var loginDto = new LoginDto { /* Inicialize as propriedades conforme necessário */ };
        var respostaEsperada = new RespostaPadrao { /* Inicialize as propriedades conforme necessário */ };
        _mockAutenticacaoService.Setup(service => service.Login(loginDto)).ReturnsAsync(respostaEsperada);

        // Act
        var result = await _controller.Login(loginDto);

        // Assert
        Assert.Equal(respostaEsperada, result);
    }
}
