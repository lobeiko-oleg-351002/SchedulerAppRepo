using BLL.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching.Base
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        private const int EXPIRATION_TIME_MINUTES = 10;
        private const int SLIDING_EXPIRATION_TIME_MINUTES = 2;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _cache = distributedCache;
        }
        public T Get<T>(string key)
        {
            var userData = _cache.Get(key);
            try
            {
                return DecodeObject<T>(userData);
            }
            catch
            {
                return default(T);
            }
        }

        private T DecodeObject<T>(byte[] bytes)
        {
            var str = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<T>(str);
        }

        public void Set<T>(string key, T model)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(EXPIRATION_TIME_MINUTES)).SetSlidingExpiration(TimeSpan.FromMinutes(SLIDING_EXPIRATION_TIME_MINUTES));
            _cache.Set(key,
                       Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)), 
                       options);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
