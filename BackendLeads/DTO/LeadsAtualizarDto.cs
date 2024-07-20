using BackendLeads.Models;
using System.ComponentModel.DataAnnotations;

namespace BackendLeads.DTO
{
    public class LeadsAtualizarDto
    {
        
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public virtual List<Endereco>? Enderecos { get; set; }
    }
}
