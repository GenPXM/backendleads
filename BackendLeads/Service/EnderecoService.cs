using AutoMapper;
using BackendLeads.Data;
using BackendLeads.DTO;
using BackendLeads.Models;
using BackendLeads.Service.Interface;
using BackendLeads.Utils;
using Microsoft.EntityFrameworkCore;

namespace BackendLeads.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly AppDbContext _DbContext;
        private readonly IMapper _mapper;
        private readonly IRequisicoesApiAutenticacao _requisicao;

        public EnderecoService(AppDbContext dbContext, IMapper mapper, IRequisicoesApiAutenticacao requisicao)
        {
            _DbContext = dbContext;
            _mapper = mapper;
            _requisicao = requisicao;
        }
        public async Task<RespostaPadrao> AdicionarEndereco(EnderecoDto enderecoDto)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                Endereco endereco = new Endereco();
                endereco.CEP = enderecoDto.CEP;
                endereco.Rua = enderecoDto.Rua;
                endereco.Bairro = enderecoDto.Bairro;
                endereco.Numero = enderecoDto.Numero;
                endereco.Cidade = enderecoDto.Cidade;
                endereco.Estado = enderecoDto.Estado;
                endereco.Complemento = enderecoDto.Complemento;
                
                await _DbContext.Enderecos.AddAsync(endereco);
                await _DbContext.SaveChangesAsync();
                resposta.SetSucesso("Salvo com sucesso", endereco);
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }

        public Task<RespostaPadrao> ApagarEndereco(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> AtualizarLeads(AtualizarEnderecoDto enderecoAtualizar, int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespostaPadrao> BuscarTodosEnderecos()
        {
            throw new NotImplementedException();
        }
    }
}
