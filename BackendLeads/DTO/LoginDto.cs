using System.ComponentModel.DataAnnotations;

namespace BackendLeads.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "CPF is required")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
