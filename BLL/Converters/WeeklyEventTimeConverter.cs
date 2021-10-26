using BLL.Converters.Interface;
using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class WeeklyEventTimeConverter : IWeeklyEventTimeConverter
    {
        private readonly IDayOfWeekConverter DayOfWeekConverter;
        public WeeklyEventTimeConverter(IDayOfWeekConverter dayOfWeekConverter)
        {
            dayOfWeekConverter = DayOfWeekConverter ?? throw new ArgumentNullException(nameof(DayOfWeekConverter));
        }
        public WeeklyEventTime ConvertToEntity(WeeklyEventTimeViewModel model)
        {
            WeeklyEventTime result = new WeeklyEventTime();

            result.Id = model.Id;
            result.Time = model.Time;
            model.DaysOfWeek.ForEach(item => result.DaysOfWeek.Add(DayOfWeekConverter.ConvertToEntity(item)));
  
            return result;
        }

        public WeeklyEventTimeViewModel ConvertToViewModel(WeeklyEventTime entity)
        {
            WeeklyEventTimeViewModel result = new WeeklyEventTimeViewModel();

            result.Id = entity.Id;
            result.Time = entity.Time;
            entity.DaysOfWeek.ForEach(item => result.DaysOfWeek.Add(DayOfWeekConverter.ConvertToViewModel(item)));

            return result;
        }
    }
}
