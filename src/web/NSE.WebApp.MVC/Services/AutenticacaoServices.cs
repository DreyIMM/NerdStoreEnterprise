using NSE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoServices : IAutenticacaoServices
    {

        private readonly HttpClient _httpClient;

        public AutenticacaoServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(UsuarioLogin usuariologin)
        {
            var loginContent = new StringContent
            (
                    JsonSerializer.Serialize(usuariologin), Encoding.UTF8, mediaType: "application/json"
            );

            var response = await _httpClient.PostAsync("https://localhost:44396/api/identidade/autenticar", loginContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = new StringContent
            (
                    JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8, mediaType: "application/json"
            );

            var response = await _httpClient.PostAsync("https://localhost:44396/api/identidade/nova-conta", registroContent);

            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }

}
