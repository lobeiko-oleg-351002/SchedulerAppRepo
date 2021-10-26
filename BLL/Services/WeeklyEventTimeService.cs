using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WeeklyEventTimeService : Service<WeeklyEventTime, WeeklyEventTimeViewModel>, IWeeklyEventTimeService
    {
        public WeeklyEventTimeService(IWeeklyEventTimeRepository WeeklyEventTimeRepository, IWeeklyEventTimeConverter WeeklyEventTimeConverter) 
            : base(WeeklyEventTimeRepository, WeeklyEventTimeConverter)
        {

        }

    }
}
