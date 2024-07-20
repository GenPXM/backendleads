using AutoMapper;
using BackendLeads.Data;
using BackendLeads.DTO;
using BackendLeads.Models;
using BackendLeads.Service.Interface;
using BackendLeads.Utils;
using System.Text;

namespace BackendLeads.Service
{
    public class LeadsService : ILeadsService
    {
        private readonly AppDbContext _DbContext;
        private readonly IMapper _mapper;
        private readonly IRequisicoesApiAutenticacao _requisicao;

        public LeadsService(AppDbContext dbContext, IMapper mapper, IRequisicoesApiAutenticacao requisicao)
        {
            _DbContext = dbContext;
            _mapper = mapper;
            _requisicao = requisicao;
        }

        public async Task<RespostaPadrao> AdicionarLeads(LeadsDto leadsDto)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            Leads leads = _mapper.Map<Leads>(leadsDto);
            var valida_cpf = new ValidationCpf();
            if (!valida_cpf.ValidaCpf(leads.Cpf))
            {
                resposta.SetChamadaInvalida("Cpf inválido, insira novamente");
                return resposta;
            }
            try
            {
                CadastrarUsuarioDto cadastrarUsuarioDto = new CadastrarUsuarioDto();
                var nome = leads.Nome.Replace(" ", "");
                leadsDto.Nome = RemoveAcentos(nome);
                leadsDto.EnderecoId = leads.EnderecoId;
                leadsDto.Telefone = leads.Telefone;
                leadsDto.Email = leads.Email;   
                leadsDto.DataRealizacao = leads.DataRealizacao;
                
                RespostaPadrao result = new RespostaPadrao();
                result = await _requisicao.PostRequestAsync(cadastrarUsuarioDto);

                await _DbContext.Leads.AddAsync(leads);
                await _DbContext.SaveChangesAsync();


                resposta.SetSucesso("Cadastrado com Sucesso", leads);
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }

        }

        public Task<RespostaPadrao> ApagarLeads(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> AtualizarLeads(LeadsAtualizarDto leadsAtualizar, int id)
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

        public Task<RespostaPadrao> BuscarTodosLeads()
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
