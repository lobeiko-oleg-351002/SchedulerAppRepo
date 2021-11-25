using Microsoft.Extensions.Caching.Memory;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching.Base
{
    public interface ICacheService<T>
        where T : ViewModel
    {
        public T Get(string id);
        public void Set(string id, T model);
        public void Remove(string id);
    }
}
