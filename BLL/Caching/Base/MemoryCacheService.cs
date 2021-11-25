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
    public class MemoryCacheService<T> : ICacheService<T>
        where T : ViewModel
    {
        private const int EXPIRATION_TIME_MINUTES = 5;

        private readonly IMemoryCache _cache;
        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache; 
        }
        public T Get(string id)
        {
            T model;
            _cache.TryGetValue(id, out model);
            return model;
        }

        public void Remove(string id)
        {
            _cache.Remove(id);
        }

        public void Set(string id, T model)
        {
            _cache.Set(id, model, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(EXPIRATION_TIME_MINUTES)));
        }
    }
}
