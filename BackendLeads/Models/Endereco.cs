using System.Text.Json.Serialization;

namespace BackendLeads.Models
{
    public class Endereco
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set;}
        [JsonIgnore]
        public string Complemento { get; set;}
        [JsonIgnore]
        public string CEP { get; set;}
        public string Cidade { get; set; }
        public string Estado {  get; set; }
        public virtual Leads Lead { get; set; }

    }
}
