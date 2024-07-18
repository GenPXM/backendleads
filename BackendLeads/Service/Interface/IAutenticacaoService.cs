using BackendLeads.DTO;
using BackendLeads.Utils;

namespace BackendLeads.Service.Interface
{
    public interface IAutenticacaoService
    {
        Task<RespostaPadrao> RegistrarGestor(CadastrarUsuarioDto model);
        Task<RespostaPadrao> RegistrarAdmin(CadastrarUsuarioDto model);
        Task<RespostaPadrao> RegistrarLeads(CadastrarUsuarioDto model);
        Task<RespostaPadrao> Login(LoginDto model);
    }
}
