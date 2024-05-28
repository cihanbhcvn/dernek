using Entities.Concrete;

namespace WebUI.Services
{
    public interface IDataService
    {
        public Task<IEnumerable<object>> GetAllAsync(string url);
        public Task AddAsync( string url,object tObject);
        public Task UpdateAsync(string url, object tObject);
        public Task DeleteAsync(string url,int id);
        public Task<object> GetAsync(string url,int id);
    }
}
