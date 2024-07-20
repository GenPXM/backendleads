using BackendLeads.Models;

namespace BackendLeads.DTO
{
    public class EnderecoDto
    {
       
      
        //public int LeadsId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
       
        public string Complemento { get; set; }
      
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        //public virtual Leads Lead { get; set; }

    }
}
