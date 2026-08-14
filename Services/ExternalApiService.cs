using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace MiPrimerAPI.Services
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;

        public ExternalApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetUsersAsync()
        {
            // Usamos otra URL pública que nunca bloquea las conexiones para probar
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error de conexión. Código: {response.StatusCode}");
            }
                
            return await response.Content.ReadAsStringAsync();
        }
    }
}