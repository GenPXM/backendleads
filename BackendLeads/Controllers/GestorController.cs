using BackendLeads.DTO;
using BackendLeads.Services.Interface;
using BackendLeads.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackendLeads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GestorController : Controller
    {
        private readonly IGestorService _gestorService;
        public GestorController(IGestorService gestorService)
        {
            _gestorService = gestorService;
        }
        [HttpPost]
        [Route("cadastrarGestor")]
        public async Task<RespostaPadrao> Cadastrar([FromBody] GestorDto gestor)
        {
            return await _gestorService.AdicionarGestor(gestor);
        }
    }
}
