using BackendLeads.Models;
using System.ComponentModel.DataAnnotations;

namespace BackendLeads.DTO
{
    public class LeadsDto
    {
    
        
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataRealizacao { get; set; }
        //public virtual List<Endereco>? Enderecos { get; set; }
    }
}
