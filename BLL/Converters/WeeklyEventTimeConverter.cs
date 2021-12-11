using BLL.Converters.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class WeeklyEventTimeConverter : IWeeklyEventTimeConverter
    {
        private readonly IDayOfWeekRepository _dayOfWeekRepository;
        public WeeklyEventTimeConverter(IDayOfWeekRepository dayOfWeekRepository)
        {
            _dayOfWeekRepository = dayOfWeekRepository;
        }
        public WeeklyEventTime ConvertToEntity(WeeklyEventTimeCreateModel model)
        {
            WeeklyEventTime result = new WeeklyEventTime();

            result.Id = model.Id;
            result.Time = model.Time;
            model.DaysOfWeek.ForEach(item => result.DaysOfWeek.Add(_dayOfWeekRepository.Get(item).Result));
  
            return result;
        }

        public WeeklyEventTimeViewModel ConvertToViewModel(WeeklyEventTime entity)
        {
            WeeklyEventTimeViewModel result = new WeeklyEventTimeViewModel();

            result.Id = entity.Id;
            result.Time = entity.Time;
            entity.DaysOfWeek.ForEach(item => result.DaysOfWeek.Add(item));

            return result;
        }
    }
}
