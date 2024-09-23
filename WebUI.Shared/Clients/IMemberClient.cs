using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Shared.Clients
{
    public interface IMemberClient<T> where T : class, IEntity, new()
    {
        public Task<IDataResult<IList<T>>> GetAll(Expression<Func<T, bool>> filter = null);
    }

    public class MemberClient : IMemberClient<Member>
    {
        private readonly HttpClient _httpClient;
        public MemberClient(HttpClient client) 
        {
            _httpClient = client;
        }
        public async Task<IDataResult<IList<Member>>> GetAll(Expression<Func<Member, bool>> filter = null)
        {
            return await _httpClient.GetFromJsonAsync<IDataResult<IList<Member>>>("");
        }
    }
}
