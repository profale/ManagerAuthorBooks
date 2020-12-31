using ManagerAuthorBooks.Domain.Cache.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Cache
{
    public class CacheService : ICacheService
    {
        public Task Save<T>(T obj, string key, int expirationTimeInMinutes = 5)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
