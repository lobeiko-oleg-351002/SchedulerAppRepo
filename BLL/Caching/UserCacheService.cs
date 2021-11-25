using BLL.Caching.Base;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching
{
    public class UserCacheService : CacheService<StudentViewModel>, ICacheService<StudentViewModel>
    {
        public UserCacheService(ICacheService<StudentViewModel> cache) : base(cache, nameof(StudentViewModel))
        {
        }
    }
}
