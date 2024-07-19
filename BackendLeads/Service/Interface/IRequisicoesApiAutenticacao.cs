using BackendLeads.DTO;
using BackendLeads.Utils;

namespace BackendLeads.Service.Interface
{
    public interface IRequisicoesApiAutenticacao
    {
        Task<RespostaPadrao> PostRequestAsync(CadastrarUsuarioDto usuario);
        Task<RespostaPadrao> PostRequestGestorAsync(CadastrarUsuarioDto usuario);
    }
}
