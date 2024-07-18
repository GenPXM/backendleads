using System.Text.Json.Serialization;

namespace BackendLeads.Models
{
    public class Gestor
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Funcao {  get; set; }
        public string Email { get; set; }
        public string Telefone {  get; set; }

    }
}
