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
        public T Get<T>(string id, string prefix)
        {
            var userData = _cache.Get(GetKey(id, prefix));
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

        public void Set<T>(string id, T model, string prefix)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(EXPIRATION_TIME_MINUTES)).SetSlidingExpiration(TimeSpan.FromMinutes(SLIDING_EXPIRATION_TIME_MINUTES));
            _cache.Set(GetKey(id, prefix),
                       Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)), 
                       options);
        }

        public void Remove(string id, string prefix)
        {
            _cache.Remove(GetKey(id, prefix));
        }

        private string GetKey(string id, string prefix)
        {
            return prefix + id;
        }
    }
}
