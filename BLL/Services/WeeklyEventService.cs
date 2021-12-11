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
        private readonly IWeeklyEventTimeRepository _weeklyEventTimeRepository;
        public WeeklyEventService(IWeeklyEventRepository weeklyEventRepository, ISubscriberService subscriberService, IWeeklyEventTimeRepository weeklyEventTimeRepository, IWeeklyEventConverter weeklyEventConverter) 
            : base(weeklyEventRepository, subscriberService, weeklyEventConverter)
        {
            _weeklyEventTimeRepository = weeklyEventTimeRepository ?? throw new ArgumentNullException(nameof(_weeklyEventTimeRepository));
        }

        public override async Task<WeeklyEventViewModel> Create(WeeklyEventCreateModel entity)
        {
            var model = _converter.ConvertToEntity(entity);
            var list = new List<WeeklyEventTime>();
            foreach (var dateAndTime in model.DateAndTime)
            {
                list.Add(_weeklyEventTimeRepository.Create(dateAndTime).Result);
            }
            model.DateAndTime = list;

            var result = await _repository.Create(model);
            return _converter.ConvertToViewModel(result);
        }

        public List<WeeklyEventViewModel> GetByChiefIdAndDateTimeRange(Guid? chiefId, DateTimeRange range)
        {
            var allEntities = _repository.GetAll();

            var query = GetByChiefId(chiefId, allEntities).AsEnumerable();  //client evaluation, because the following "daysOfWeekFromInputRange" requires a load to memory


            var daysOfWeekFromInputRange = GetDaysOfWeek(range).AsQueryable();

            if (range != null)
            {
                query = from entity in query
                        where
                            (from dateTime in entity.DateAndTime
                                 from dayOfWeek in dateTime.DaysOfWeek
                                     join item in daysOfWeekFromInputRange on dayOfWeek.Name equals item
                                  // from requestedDay in daysOfWeekFromInputRange
                                  // where requestedDay == dayOfWeek.Name
                             select dateTime).Any()                                                     
                        select entity;
            }
            var result = query.ToList();
            return result.Select(_converter.ConvertToViewModel).ToList();
        }

        private List<string> GetDaysOfWeek(DateTimeRange range)
        {
            List<string> result = new List<string>();
            const int DaysInWeekCount = 7;
            while ((range.Start <= range.End) || (result.Count < DaysInWeekCount))
            {
                string day = range.Start.DayOfWeek.ToString();
                if (!result.Contains(day))
                {
                    result.Add(range.Start.DayOfWeek.ToString());
                }
                range.Start = range.Start.AddDays(1);
            }
            return result;
        }
    }
}
