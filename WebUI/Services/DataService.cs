using Entities.Concrete;
using Microsoft.Data.SqlClient;

namespace WebUI.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<object>> GetAllAsync(string url)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<object>>(url);
        }

        public async Task<object> GetAsync(string url,int id)
        {
            return await _httpClient.GetAsync($"{url}/{id}");
        }

        public async Task AddAsync(string url, object tObject)
        {
            var result = await _httpClient.PostAsJsonAsync(url, tObject);
        }

        public async Task UpdateAsync(string url, object tObject)
        {
            await _httpClient.PutAsJsonAsync(url, tObject);
        }

        public async Task DeleteAsync(string url,int id)
        {
            await _httpClient.DeleteAsync($"{url}/{id}");
        }
    }
}
