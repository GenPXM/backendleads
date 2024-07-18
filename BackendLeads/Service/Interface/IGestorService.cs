using System;
using BackendLeads.DTO;
using BackendLeads.Utils;


namespace BackendLeads.Services.Interface
{
	public interface IGestorService
	{
        Task<RespostaPadrao> BuscarTodosGestores();
        Task<RespostaPadrao> BuscarPorId(int id);
        Task<RespostaPadrao> BuscarPorCpf(string id);
        Task<RespostaPadrao> AdicionarGestor(GestorDto gestor, string token, string idLogin);
        Task<RespostaPadrao> Atualizar(GestorAtualizarDto gestor, int id);
        Task<RespostaPadrao> Apagar(int id);
       
    }
}
