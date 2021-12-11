using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using SchedulerMigrations.Data;
using SchedulerModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DayOfWeekRepository : Repository<DayOfWeek>, IDayOfWeekRepository
    {
        public DayOfWeekRepository(SchedulerDbContext context, ILogMessageManager<DayOfWeek> logMessageManager) : base(context, logMessageManager)
        {

        }
    }
}
