using Entities.Concrete;

namespace WebUI.Services.EntityServices
{
    public interface IMemberService { 

        public Task<IEnumerable<Member>> GetAllAsync();
        public Task AddAsync(Member member);
        public Task UpdateAsync(Member member);
        public Task DeleteAsync(int id);
        public Task<object> GetAsync(int id);
    }
}
