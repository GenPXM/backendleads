using BackendLeads.DTO;
using BackendLeads.Utils;

namespace BackendLeads.Service.Interface
{
    public interface ILeadsService
    {
        Task<RespostaPadrao> BuscarTodosLeads();
        Task<RespostaPadrao> BuscarPorId(int id);
        Task<RespostaPadrao> BuscarPorCpf(string id);
        Task<RespostaPadrao> AdicionarLeads(LeadsDto leadsDto);
        Task<RespostaPadrao> AtualizarLeads(LeadsAtualizarDto leadsAtualizar, int id);
        Task<RespostaPadrao> ApagarLeads(int id);
    }
}
