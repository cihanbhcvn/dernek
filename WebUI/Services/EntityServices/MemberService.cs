

using Entities.Concrete;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebUI.Services.EntityServices
{

    public class MemberService : IMemberService
    {

        private readonly IDataService _dataService;

        public MemberService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
            var result = await _dataService.GetAllAsync("/api/Members/getall");
            return result.Cast<Member>().ToList();
           
        }

        public async Task<object> GetAsync(int id)
        {
            var result = await _dataService.GetAsync("/api/Members/get/",id);
            return result;
        }

        public async Task AddAsync(Member member)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/Members/add", member);
        }

        public async Task UpdateAsync(Member member)
        {
            await _httpClient.PutAsJsonAsync("/api/Members/update", member);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"/api/Members/get/{id}");
        }
    }
}
