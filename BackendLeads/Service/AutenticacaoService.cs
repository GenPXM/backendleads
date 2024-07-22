using BackendLeads.DTO;
using BackendLeads.Models;
using BackendLeads.Service.Interface;
using BackendLeads.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendLeads.Service
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AutenticacaoService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        public async Task<RespostaPadrao> Login(LoginDto model)
        {
            var resposta = new RespostaPadrao("Login efetuado com sucesso!");
            LoginSucessoDto login = new LoginSucessoDto();
            try
            {
                //var user = await _userManager.FindByNameAsync(model.UserName);
                var user = await _userManager.Users.Where(x => x.CPF == model.Cpf).FirstOrDefaultAsync();
                if (user == null)
                {
                    resposta.SetErroInterno("Usuário não existe");
                    return resposta;
                }
                var resultadoIdentity = await _signInManager
               .PasswordSignInAsync(user.UserName, model.Password, false, false);
                if (resultadoIdentity.Succeeded)
                {
                    var identityUser = _signInManager
                        .UserManager
                        .Users
                        .FirstOrDefault(usuario =>
                         usuario.NormalizedUserName == user.UserName.ToUpper());
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.PrimarySid, user.Id),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var token = CreateToken(authClaims);
                    login.Id = user.Id;
                    login.UserName = user.UserName;
                    login.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    resposta.Retorno = login;

                }
                else
                {
                    resposta.SetErroInterno("Cpf ou senha incorreta");
                }
                return resposta;
            }
            catch (Exception e)
            {
                resposta.SetErroInterno(e.Message + ". " + e.InnerException);
                return resposta;
            }
        }

        public async Task<RespostaPadrao> RegistrarAdmin(CadastrarUsuarioDto model)
        {
            RespostaPadrao resposta = new RespostaPadrao("Usuário cadastrado com sucesso!");
            try
            {
                var valida_cpf = new ValidationCpf();
                if (!valida_cpf.ValidaCpf(model.Cpf))
                {
                    resposta.SetChamadaInvalida("Cpf inválido, insira novamente");
                    return resposta;
                }
                var cpfExists = await _userManager.Users.Where(x => x.CPF == model.Cpf).FirstOrDefaultAsync();
                var nameExists = await _userManager.FindByNameAsync(model.Username);
                var role = model.Role;
                if (cpfExists != null)
                {
                    resposta.SetErroInterno("Cpf de usuário já cadastrado");
                    return resposta;
                }
                if (nameExists != null)
                {
                    resposta.SetErroInterno("Nome de usuário já cadastrado.");
                    return resposta;
                }
                if (role <= 0 || role > 3)
                {
                    resposta.SetErroInterno("Nível de administrador deve ser de 1 a 3");
                    return resposta;
                }
                if (model.Password != model.ConfirmPassword)
                {
                    resposta.SetErroInterno("Senha e confirmação estão diferentes, digite novamente");
                    return resposta;
                }
                ApplicationUser user = new()
                {
                    CPF = model.Cpf,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    
                    
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    resposta.SetBadRequest("Não foi possível criar o usuário, tente novamente mais tarde.");
                    return resposta;
                }
                await VerificaRoleAsync(role, user);
                string newId = user.Id;
                resposta.Retorno = newId;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.SetErroInterno(e.Message + ". " + e.InnerException);
                return resposta;
            }
        }

        public Task<RespostaPadrao> RegistrarGestor(CadastrarUsuarioDto model)
        {
            throw new NotImplementedException();
        }

        public async  Task<RespostaPadrao> RegistrarLeads(CadastrarUsuarioDto model)
        {
            RespostaPadrao resposta = new RespostaPadrao("Usuário cadastrado com sucesso!");
            try
            {
                var valida_cpf = new ValidationCpf();
                if (!valida_cpf.ValidaCpf(model.Cpf))
                {
                    resposta.SetChamadaInvalida("Cpf inválido, insira novamente");
                    return resposta;
                }
                var cpfExists = await _userManager.Users.Where(x => x.CPF == model.Cpf).FirstOrDefaultAsync();
                var nameExists = await _userManager.FindByNameAsync(model.Username);
                var role = model.Role;
                if (cpfExists != null)
                {
                    resposta.SetErroInterno("Cpf de usuário já cadastrado");
                    return resposta;
                }
                if (nameExists != null)
                {
                    resposta.SetErroInterno("Nome de usuário já cadastrado.");
                    return resposta;
                }
                if (role != 3)
                {
                    resposta.SetErroInterno("Nível de Leads deve ser 3");
                    return resposta;
                }
                if (model.Password != model.ConfirmPassword)
                {
                    resposta.SetErroInterno("Senha e confirmação estão diferentes, digite novamente");
                    return resposta;
                }
                ApplicationUser user = new()
                {
                    CPF = model.Cpf,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    resposta.SetBadRequest("Não foi possível criar o usuário, tente novamente mais tarde.");
                    return resposta;
                }
                await VerificaRoleAsync(role, user);
                string newId = user.Id;
                resposta.Retorno = newId;
                return resposta;
            }
            catch (Exception e)
            {
                resposta.SetErroInterno(e.Message + ". " + e.InnerException);
                return resposta;
            }

        }

        public async Task VerificaRoleAsync(int role, ApplicationUser user)
        {
            var roleNames = new List<string>(); switch (role)
            {
                case 1:
                    roleNames.Add(UserRolesDto.AdminMaster);
                    roleNames.Add(UserRolesDto.AdminGestor);
                    roleNames.Add(UserRolesDto.UsuarioLeads);
                    break;
                case 2:
                    roleNames.Add(UserRolesDto.UsuarioLeads);
                    roleNames.Add(UserRolesDto.UsuarioLeads);
                    break;
                case 3:
                    roleNames.Add(UserRolesDto.UsuarioLeads);
                    break;
                default:
                    break;
            }
            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
                if (await _roleManager.RoleExistsAsync(roleName))
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        public JwtSecurityToken CreateToken(List<Claim> authClaims)
        {

            var credenciais = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddYears(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(credenciais, SecurityAlgorithms.HmacSha256)

                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return token;
        }
    }
}
