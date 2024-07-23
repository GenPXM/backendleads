using BackendLeads.Data;
using BackendLeads.DTO;
using BackendLeads.Service.Interface;
using BackendLeads.Services.Interface;
using BackendLeads.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendLeads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : Controller
    {
        private readonly AppDbContext _DbContext;
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
        [HttpGet]
        [Route("listarLeads")]
        public async Task<RespostaPadrao> ListarLeads()
        {
            return await _leadsService.BuscarTodosLeads();
        }
        [HttpGet]
        [Route("listarPorIdLeads")]
        public async Task<RespostaPadrao> ListarLeadsId(int id)
        {
            return await _leadsService.BuscarPorId(id);
        }
        [HttpGet]
        [Route("listarPorCpfLeads")]
        public async Task<RespostaPadrao> ListarLeadsCpf(string cpf)
        {
            return await _leadsService.BuscarPorCpf(cpf);
        }
        [HttpPut]
        [Route("atualizarLeads")]
        public async Task<RespostaPadrao> AtualizarLeads(LeadsAtualizarDto leadsAtualizarDto, int id)
        {
            return await _leadsService.AtualizarLeads(leadsAtualizarDto, id);
        }
        [HttpDelete]
        [Route("deletarLeads")]
        public async Task<RespostaPadrao> DeletarLeads(int id)
        {
            return await _leadsService.ApagarLeads(id);
        }
        [HttpGet("verificarCpfLeads")]
        public async Task<RespostaPadrao> VerificarCpfLead([FromQuery] string cpf)
        {
            var resposta = await _leadsService.VerificarCpfExistente(cpf);
            return resposta;
        }

    }
}
