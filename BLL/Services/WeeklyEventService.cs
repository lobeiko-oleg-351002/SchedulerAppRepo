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
    public class WeeklyEventService : EventService<WeeklyEvent, WeeklyEventViewModel>, IWeeklyEventService
    {
        private readonly IWeeklyEventTimeService WeeklyEventTimeService;
        public WeeklyEventService(IWeeklyEventRepository weeklyEventRepository, ISubscriberService subscriberService, IWeeklyEventTimeService weeklyEventTimeService, IWeeklyEventConverter weeklyEventConverter) 
            : base(weeklyEventRepository, subscriberService, weeklyEventConverter)
        {
            WeeklyEventTimeService = weeklyEventTimeService ?? throw new ArgumentNullException(nameof(WeeklyEventTimeService));
        }

    }
}
