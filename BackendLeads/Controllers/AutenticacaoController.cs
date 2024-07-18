using BackendLeads.DTO;
using BackendLeads.Service.Interface;
using BackendLeads.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendLeads.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }
        //[Authorize(Roles = "AdminMaster")]
        [HttpPost]
        [Route("cadastrar")]
        public async Task<RespostaPadrao> RegistrarAdmin([FromBody] CadastrarUsuarioDto model)
        {

            return await _autenticacaoService.RegistrarAdmin(model);
        }
        [Authorize(Roles = "AdminGestor")]
        [HttpPost]
        [Route("cadastrarLeads")]
        public async Task<RespostaPadrao> RegistrarAluno([FromBody] CadastrarUsuarioDto model)
        {

            return await _autenticacaoService.RegistrarLeads(model);
        }
        [HttpPost]
        [Route("login")]
        public async Task<RespostaPadrao> Login([FromBody] LoginDto model)
        {
            return await _autenticacaoService.Login(model);
        }
    }
}
