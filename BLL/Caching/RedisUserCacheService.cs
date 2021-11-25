using BLL.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching
{
    public class RedisUserCacheService : IUserCacheService
    {
        private readonly IDistributedCache _cache;

        private const int EXPIRATION_TIME_MINUTES = 10;
        private const int SLIDING_EXPIRATION_TIME_MINUTES = 2;

        public RedisUserCacheService(IDistributedCache distributedCache)
        {
            _cache = distributedCache;
        }
        public StudentViewModel GetUserFromCache(Guid userId)
        {
            var userData = _cache.Get(userId.ToString());
            try
            {
                return DecodeObject(userData);
            }
            catch
            {
                return null;
            }
        }

        private StudentViewModel DecodeObject(byte[] bytes)
        {
            var str = Encoding.UTF8.GetString(bytes);
            return JsonConvert.DeserializeObject<StudentViewModel>(str);
        }

        public void SetUserToCache(StudentViewModel user)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(EXPIRATION_TIME_MINUTES)).SetSlidingExpiration(TimeSpan.FromMinutes(SLIDING_EXPIRATION_TIME_MINUTES));
            _cache.Set(user.Id.ToString(),
                                  Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user)), 
                                  options);
        }
    }
}
