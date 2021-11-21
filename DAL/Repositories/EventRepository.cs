using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using SchedulerMigrations.Data;
using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EventRepository<TEntity> : Repository<TEntity>, IEventRepository<TEntity>
        where TEntity : Event
    {
        public EventRepository(SchedulerDbContext context, ILogMessageManager<TEntity> logMessageManager) : base(context, logMessageManager)
        {

        }
    }
}
