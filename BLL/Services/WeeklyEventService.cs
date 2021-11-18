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
    public class WeeklyEventService : EventService<WeeklyEvent, WeeklyEventViewModel, WeeklyEventCreateModel>, IWeeklyEventService
    {
        private readonly IWeeklyEventTimeService _weeklyEventTimeService;
        public WeeklyEventService(IWeeklyEventRepository weeklyEventRepository, ISubscriberService subscriberService, IWeeklyEventTimeService weeklyEventTimeService, IWeeklyEventConverter weeklyEventConverter) 
            : base(weeklyEventRepository, subscriberService, weeklyEventConverter)
        {
            _weeklyEventTimeService = weeklyEventTimeService ?? throw new ArgumentNullException(nameof(_weeklyEventTimeService));
        }

    }
}
