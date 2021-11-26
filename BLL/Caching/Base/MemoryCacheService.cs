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
        public T Get<T>(string id, string prefix)
        {
            T model;
            _cache.TryGetValue(GetKey(id, prefix), out model);
            return model;
        }

        public void Remove(string id, string prefix)
        {
            _cache.Remove(GetKey(id, prefix));
        }

        public void Set<T>(string id, T model, string prefix)
        {
            _cache.Set(GetKey(id, prefix), model, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(EXPIRATION_TIME_MINUTES)));
        }

        private string GetKey(string id, string prefix)
        {
            return prefix + id;
        }
    }
}
