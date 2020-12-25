using System;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<object> GetAsync(string key)
        {
            var cached = await _distributedCache.GetStringAsync(key);
            if (cached != null)
                return await Task.FromResult(JsonConvert.DeserializeObject(cached, 
                    new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects }));

            return await Task.FromResult<object>(null);
        }

        public async Task SetAsync(string key, object value, TimeSpan expirationTimeFromNow)
        {
            var serializedResponse = JsonConvert.SerializeObject(value, 
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

            await _distributedCache.SetStringAsync(key, serializedResponse, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expirationTimeFromNow
            });
        }
        
        public async Task RemoveAsync(string key)
        {
            if (key != null)
            {
                await _distributedCache.RemoveAsync(key);
            }
        }
    }
}