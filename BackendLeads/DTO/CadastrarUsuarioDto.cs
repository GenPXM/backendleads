using System.ComponentModel.DataAnnotations;

namespace BackendLeads.DTO
{
    public class CadastrarUsuarioDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Cpf é obrigatório")]
        public string? Cpf { get; set; }
        [Required(ErrorMessage = "Nível de administrador é obrigatório")]
        public int Role { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email é obrigatório")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Confirmação de senha é obrigatória")]
        public string? ConfirmPassword { get; set; }
    }
}
