using BLL.Caching;
using SchedulerApp.Caching;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Caching
{
    public class CacheTypeResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public CacheTypeResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUserCacheService Resolve()
        {
            string cacheType = "Distributed";

            if (cacheType == "InMemory")
            {
                return (IUserCacheService)_serviceProvider.GetService(typeof(MemoryUserCacheService));
            }
            if (cacheType == "Distributed")
            {
                return (IUserCacheService)_serviceProvider.GetService(typeof(RedisUserCacheService));
            }
            throw new Exception("Invalid Cache type");
        }
    }
}
