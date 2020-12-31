using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Cache.Contract
{
    public interface ICacheService
    {
        Task Save<T>(T obj, string key, int expirationTimeInMinutes = 5);
        Task<T> Get<T>(string key);
        Task Remove(string key);
    }
}
