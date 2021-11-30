using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching.Base
{
    public class MemoryCacheService : ICacheService
    {
        private const int EXPIRATION_TIME_MINUTES = 5;

        private readonly IMemoryCache _cache;
        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache; 
        }
        public T Get<T>(string key)
        {
            T model;
            _cache.TryGetValue(key, out model);
            return model;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set<T>(string key, T model)
        {
            _cache.Set(key, model, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(EXPIRATION_TIME_MINUTES)));
        }

    }
}
