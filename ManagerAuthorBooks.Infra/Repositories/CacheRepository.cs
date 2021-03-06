﻿using ManagerAuthorBooks.Domain.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAuthorBooks.Infra.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IDistributedCache _distributedCache;

        public CacheRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        private static DistributedCacheEntryOptions Create(int expirationTimeInMinutes)
        {
            var opcoes = new DistributedCacheEntryOptions();
            opcoes.SetAbsoluteExpiration(TimeSpan.FromMinutes(expirationTimeInMinutes));
            return opcoes;
        }

        public async Task Save<T>(T obj, string key, int expirationTimeInMinutes = 5)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            if (json != "null")
            {
                _distributedCache.Remove(key);
                await _distributedCache.SetStringAsync(key, json, Create(expirationTimeInMinutes));
            }
        }

        public async Task<T> Get<T>(string key)
        {
            var value = await _distributedCache.GetStringAsync(key);

            if (!string.IsNullOrWhiteSpace(value))
                return JsonConvert.DeserializeObject<T>(value);

            return default;
        }

        public async Task Remove(string key)
        {
            if (key != "null")
            {
                await _distributedCache.RemoveAsync(key);
            }
        }
    }
}
