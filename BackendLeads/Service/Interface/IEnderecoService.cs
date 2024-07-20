using BackendLeads.DTO;
using BackendLeads.Utils;

namespace BackendLeads.Service.Interface
{
    public interface IEnderecoService
    {
        Task<RespostaPadrao> BuscarTodosEnderecos();
        Task<RespostaPadrao> BuscarPorId(int id);
        Task<RespostaPadrao> AdicionarEndereco(EnderecoDto enderecoDto);
        Task<RespostaPadrao> AtualizarLeads(AtualizarEnderecoDto enderecoAtualizar, int id);
        Task<RespostaPadrao> ApagarEndereco(int id);
    }
}
