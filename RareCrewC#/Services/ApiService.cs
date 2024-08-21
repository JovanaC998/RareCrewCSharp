using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RareCrewC_.Models;

namespace RareCrewC_.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries";

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer your_access_token");
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var response = await _httpClient.GetStringAsync($"{_apiUrl}?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==");
            return JsonConvert.DeserializeObject<List<Employee>>(response);
        }
    }
}
