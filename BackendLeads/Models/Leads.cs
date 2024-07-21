using BackendLeads.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendLeads.Models
{
    public class Leads
    {
        [JsonIgnore]
        public int Id { get; set; }
       
        public string? Nome { get; set; }
        [Required]
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string?  Telefone { get; set; }
        public string? Rua { get; set; }
        public string? Bairro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        [JsonIgnore]
        public DateTime DataRealizacao { get; set; }
    }


}

