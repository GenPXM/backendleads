using AutoMapper;
using BackendLeads.Data;
using BackendLeads.DTO;
using BackendLeads.Models;
using BackendLeads.Service.Interface;
using BackendLeads.Services.Interface;
using BackendLeads.Utils;
using System.Text;

namespace BackendLeads.Service
{
    public class GestorService: IGestorService 
    {
        private readonly AppDbContext _DbContext;
        private readonly IMapper _mapper;
        private readonly IRequisicoesApiAutenticacao _requisicao;


        public GestorService(AppDbContext dbContext, IMapper mapper, IRequisicoesApiAutenticacao requisicao)
        {
            _DbContext = dbContext;
            _mapper = mapper;
            _requisicao = requisicao;
            
        }


        public async Task<RespostaPadrao>AdicionarGestor(GestorDto gestorDto)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            Gestor gestor = _mapper.Map<Gestor>(gestorDto);
            var valida_cpf = new ValidationCpf();
            if (!valida_cpf.ValidaCpf(gestor.Cpf))
            {
                resposta.SetChamadaInvalida("Cpf inválido, insira novamente");
                return resposta;
            }
            try
            {
               CadastrarUsuarioDto cadastrarUsuarioDto = new CadastrarUsuarioDto();
                var nome = gestor.Nome.Replace(" ", "");
                cadastrarUsuarioDto.Username = RemoveAcentos(nome);
                cadastrarUsuarioDto.Cpf = gestor.Cpf;
                cadastrarUsuarioDto.Role = 2;
                cadastrarUsuarioDto.Email = gestor.Email;
                cadastrarUsuarioDto.Password = "Startup@2024#";
                cadastrarUsuarioDto.ConfirmPassword = "Startup@2024#";
                RespostaPadrao result = new RespostaPadrao();
                result = await _requisicao.PostRequestAsync(cadastrarUsuarioDto);
                
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

        public static string RemoveAcentos(string input)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(input);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
