using Microsoft.Extensions.Caching.Memory;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Caching
{
    public interface IUserCacheService
    {
        public StudentViewModel GetUserFromCache(Guid userId);
        public StudentViewModel SetUserToCache(StudentViewModel user);
    }
}
