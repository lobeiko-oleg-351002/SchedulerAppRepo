using Microsoft.Extensions.Caching.Memory;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching.Base
{
    public interface ICacheService
    {
        public T Get<T>(string key);
        public void Set<T>(string key, T model);
        public void Remove(string key);
    }
}
