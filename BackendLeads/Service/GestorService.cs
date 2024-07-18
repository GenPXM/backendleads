using BackendLeads.Data;
using BackendLeads.DTO;
using BackendLeads.Models;
using BackendLeads.Services.Interface;
using BackendLeads.Utils;

namespace BackendLeads.Service
{
    public class GestorService: IGestorService 
    {
        private readonly AppDbContext _DbContext;


        public GestorService(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }


        public async Task<RespostaPadrao>AdicionarGestor(GestorDto gestorDto, string token, string idLogin)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
               Gestor gestor = new Gestor ();
                gestor.Nome = gestorDto.Nome;
                gestor.Cpf = gestorDto.Cpf;
                gestor.Funcao = gestorDto.Funcao;
                gestor.Telefone = gestorDto.Telefone;
                await _DbContext.Gestores.AddAsync(gestor);
                await _DbContext.SaveChangesAsync();
                resposta.SetSucesso("Cadastrado com Sucesso", gestor);
                return resposta;

            }catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }

        public Task<RespostaPadrao> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> Atualizar(GestorAtualizarDto gestor, int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> BuscarPorCpf(string id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> BuscarTodosGestores()
        {
            throw new NotImplementedException();
        }
    }
}
