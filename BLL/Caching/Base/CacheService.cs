using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching.Base
{
    public class CacheService<T> : ICacheService<T>
        where T : ViewModel
    {
        private readonly ICacheService<T> _cache;
        private readonly string _prefix;

        public CacheService(ICacheService<T> cache, string prefix)
        {
            _cache = cache;
            _prefix = prefix;
        }

        public T Get(string id)
        {
           return _cache.Get(_prefix + id);
        }

        public void Remove(string id)
        {
            _cache.Remove(_prefix + id);
        }

        public void Set(string id, T model)
        {
            _cache.Set(_prefix + id, model);
        }
    }
}
