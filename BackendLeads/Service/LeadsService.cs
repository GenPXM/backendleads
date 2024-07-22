using AutoMapper;
using BackendLeads.Data;
using BackendLeads.DTO;
using BackendLeads.Models;
using BackendLeads.Service.Interface;
using BackendLeads.Utils;
using Microsoft.EntityFrameworkCore;
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
                bool cpfExists = await _DbContext.Leads.AnyAsync(l => l.Cpf == leads.Cpf);
                if (cpfExists)
                {
                    resposta.SetChamadaInvalida("O CPF já está cadastrado.");
                    return resposta;
                }
                CadastrarUsuarioDto cadastrarUsuarioDto = new CadastrarUsuarioDto();
                var nome = leads.Nome.Replace(" ", "");
                leadsDto.Nome = RemoveAcentos(nome);
                leadsDto.Cpf = leads.Cpf;
                leadsDto.Telefone = leads.Telefone;
                leadsDto.Email = leads.Email;
                leadsDto.CEP = leads.CEP;
                leadsDto.Rua = leads.Rua;
                leadsDto.Numero = leads.Numero;
                leadsDto.Complemento = leads.Complemento;
                leadsDto.Bairro = leads.Bairro;
                leadsDto.Cidade = leads.Cidade;
                leadsDto.Estado = leads.Estado;
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

        public static string RemoveAcentos(string input)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(input);
            return Encoding.ASCII.GetString(bytes);
        }

        public async Task<RespostaPadrao> BuscarTodosLeads()
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                var leads = await _DbContext.Leads.ToListAsync();
                if (leads == null || leads.Count == 0)
                {
                    resposta.SetChamadaInvalida("Nenhum lead encontrado.");
                    return resposta;
                }

                var leadsDto = _mapper.Map<List<LeadsDto>>(leads);
                resposta.SetSucesso("Leads encontrados com sucesso.", leadsDto);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }

        public async Task<RespostaPadrao> BuscarPorId(int id)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                var lead = await _DbContext.Leads.FindAsync(id);
                if (lead == null)
                {
                    resposta.SetChamadaInvalida("Lead não encontrado.");
                    return resposta;
                }

                var leadDto = _mapper.Map<LeadsDto>(lead);
                resposta.SetSucesso("Lead encontrado com sucesso.", leadDto);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }

        public async Task<RespostaPadrao> BuscarPorCpf(string cpf)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                var lead = await _DbContext.Leads.FirstOrDefaultAsync(l => l.Cpf == cpf);
                if (lead == null)
                {
                    resposta.SetChamadaInvalida("Lead não encontrado.");
                    return resposta;
                }

                var leadDto = _mapper.Map<LeadsDto>(lead);
                resposta.SetSucesso("Lead encontrado com sucesso.", leadDto);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }

        public async Task<RespostaPadrao> AtualizarLeads(LeadsAtualizarDto leadsAtualizarDto, int id)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                var lead = await _DbContext.Leads.FindAsync(id);
                if (lead == null)
                {
                    resposta.SetChamadaInvalida("Lead não encontrado.");
                    return resposta;
                }

                _mapper.Map(leadsAtualizarDto, lead);
                _DbContext.Leads.Update(lead);
                await _DbContext.SaveChangesAsync();

                resposta.SetSucesso("Lead atualizado com sucesso.", lead);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }

        public async Task<RespostaPadrao> ApagarLeads(int id)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                var lead = await _DbContext.Leads.FindAsync(id);
                if (lead == null)
                {
                    resposta.SetChamadaInvalida("Lead não encontrado.");
                    return resposta;
                }

                _DbContext.Leads.Remove(lead);
                await _DbContext.SaveChangesAsync();

                resposta.SetSucesso("Lead apagado com sucesso.",lead);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }
    }

}
