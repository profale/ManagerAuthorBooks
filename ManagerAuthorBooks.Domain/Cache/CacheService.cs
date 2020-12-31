using ManagerAuthorBooks.Domain.Cache.Contract;
using ManagerAuthorBooks.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Domain.Cache
{
    public class CacheService : ICacheService
    {
        private ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public async Task Save<T>(T obj, string key, int expirationTimeInMinutes = 5)
        {
            await _cacheRepository.Save(obj, key, expirationTimeInMinutes);
        }

        public async Task<T> Get<T>(string key)
        {
            return await _cacheRepository.Get<T>(key);
        }

        public async Task Remove(string key)
        {
            await _cacheRepository.Remove(key);
        }
    }
}
