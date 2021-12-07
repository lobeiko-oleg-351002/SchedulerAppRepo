using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using SchedulerViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class WeeklyEventService : EventService<WeeklyEvent, WeeklyEventViewModel, WeeklyEventCreateModel>, IWeeklyEventService, IEventFilter<WeeklyEventViewModel>
    {
        private readonly IWeeklyEventTimeService _weeklyEventTimeService;
        public WeeklyEventService(IWeeklyEventRepository weeklyEventRepository, ISubscriberService subscriberService, IWeeklyEventTimeService weeklyEventTimeService, IWeeklyEventConverter weeklyEventConverter) 
            : base(weeklyEventRepository, subscriberService, weeklyEventConverter)
        {
            _weeklyEventTimeService = weeklyEventTimeService ?? throw new ArgumentNullException(nameof(_weeklyEventTimeService));
        }

        public override async Task<WeeklyEventViewModel> Create(WeeklyEventCreateModel entity)
        {
            foreach(var dateAndTime in entity.DateAndTime)
            {
                var model = await _weeklyEventTimeService.Create(dateAndTime);
                dateAndTime.Id = model.Id;
            }
            
            return await base.Create(entity);
        }

        public List<WeeklyEventViewModel> GetByChiefIdAndDateTimeRange(Guid? chiefId, DateTimeRange range)
        {
            var query = _repository.GetAll();

            query = GetByChiefId(chiefId, query);

            var daysOfWeek = GetDaysOfWeek(range);

            if (range != null)
            {
                query = from entity in query
                        where (from dateTime in entity.DateAndTime
                                   from dayOfWeek in dateTime.DaysOfWeek
                                   join item in daysOfWeek on dayOfWeek.Name equals item
                                   select new { Name = item }) != null
                        select entity;
            }
            return query.Select(_converter.ConvertToViewModel).ToList();
        }

        private List<string> GetDaysOfWeek(DateTimeRange range)
        {
            List<string> result = new List<string>();
            while (range.Start <= range.End)
            {
                result.Add(range.Start.DayOfWeek.ToString());
                range.Start = range.Start.AddDays(1);
            }
            return result;
        }
    }
}
