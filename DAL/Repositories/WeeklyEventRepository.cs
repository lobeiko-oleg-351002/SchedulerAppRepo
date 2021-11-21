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
    public class WeeklyEventRepository : EventRepository<WeeklyEvent>, IWeeklyEventRepository
    {
        public WeeklyEventRepository(SchedulerDbContext context, ILogMessageManager<WeeklyEvent> logMessageManager) : base(context, logMessageManager)
        {

        }
    }
}
