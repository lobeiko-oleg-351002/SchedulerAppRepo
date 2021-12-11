using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WeeklyEventTimeService : Service<WeeklyEventTime, WeeklyEventTimeViewModel, WeeklyEventTimeCreateModel>, IWeeklyEventTimeService
    {
        
        public WeeklyEventTimeService(IWeeklyEventTimeRepository WeeklyEventTimeRepository, IWeeklyEventTimeConverter WeeklyEventTimeConverter, IDayOfWeekRepository dayOfWeekRepository) 
            : base(WeeklyEventTimeRepository, WeeklyEventTimeConverter)
        {
            
        }

    }
}
