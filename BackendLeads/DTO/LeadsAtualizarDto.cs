using BackendLeads.Models;
using System.ComponentModel.DataAnnotations;

namespace BackendLeads.DTO
{
    public class LeadsAtualizarDto
    { 
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }

    }
}
