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
        public T Get<T>(string id, string prefix);
        public void Set<T>(string id, T model, string prefix);
        public void Remove(string id, string prefix);
    }
}
