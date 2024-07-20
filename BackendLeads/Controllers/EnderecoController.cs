using BackendLeads.DTO;
using BackendLeads.Service.Interface;
using BackendLeads.Services.Interface;
using BackendLeads.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackendLeads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }
        [HttpPost]
        [Route("cadastrarEndereco")]
        public async Task<RespostaPadrao> Cadastrar([FromBody] EnderecoDto enderecoDto)
        {
            return await _enderecoService.AdicionarEndereco(enderecoDto);
        }
    }
    
}
