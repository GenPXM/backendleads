using BackendLeads.DTO;
using BackendLeads.Service.Interface;
using BackendLeads.Services.Interface;
using BackendLeads.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BackendLeads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : Controller
    {
        private readonly ILeadsService _leadsService;
        public LeadsController(ILeadsService leadsService)
        {
            _leadsService = leadsService;
        }
        [HttpPost]
        [Route("cadastrarLeads")]
        public async Task<RespostaPadrao> Cadastrar([FromBody] LeadsDto leadsDto)
        {
            return await _leadsService.AdicionarLeads(leadsDto);
        }
    }
}
