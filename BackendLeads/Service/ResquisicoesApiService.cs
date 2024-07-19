using BackendLeads.DTO;
using BackendLeads.Service.Interface;
using BackendLeads.Utils;
using Newtonsoft.Json;
using System.Text;

namespace BackendLeads.Service
{
    public class ResquisicoesApiService : IRequisicoesApiAutenticacao
    {
        private readonly UrlStringDto _urlString;

        public ResquisicoesApiService(UrlStringDto urlString)
        {
            _urlString = urlString;
        }
        public async  Task<RespostaPadrao> PostRequestAsync(CadastrarUsuarioDto usuario)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_urlString.Identity);
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.PostAsync("api/Autenticacao/cadastrar", content))
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        response.EnsureSuccessStatusCode();
                        resposta = JsonConvert.DeserializeObject<RespostaPadrao>(responseContent.ToString());
                        return resposta;
                    }

                }
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }

        }

        public async  Task<RespostaPadrao> PostRequestGestorAsync(CadastrarUsuarioDto usuario)
        {
            RespostaPadrao resposta = new RespostaPadrao();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_urlString.Identity);
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
                    using (HttpResponseMessage response = await client.PostAsync("api/Autenticacao/cadastrarGestor", content))
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        response.EnsureSuccessStatusCode();
                        resposta = JsonConvert.DeserializeObject<RespostaPadrao>(responseContent.ToString());
                        return resposta;
                    }

                }
            }
            catch (Exception ex)
            {
                resposta.SetBadRequest(ex.Message);
                return resposta;
            }
        }
    }
}
