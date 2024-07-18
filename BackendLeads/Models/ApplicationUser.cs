using Microsoft.AspNetCore.Identity;

namespace BackendLeads.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string CPF { get; set; }
    }
}
