using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IEventRepository<TEntity> : IRepository<TEntity>
        where TEntity : Event
    {
    }
}
