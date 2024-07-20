using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendLeads.Models
{
    public class Leads
    {
        [JsonIgnore]
        public int Id { get; set; }
       
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string  Telefone { get; set; }
        [JsonIgnore]
        public DateTime DataRealizacao { get; set; }
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }


    }
}
