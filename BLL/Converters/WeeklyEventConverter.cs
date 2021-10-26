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
    public class WeeklyEventConverter : EventConverter<WeeklyEvent, WeeklyEventViewModel>, IWeeklyEventConverter
    {
        private readonly IWeeklyEventTimeConverter WeeklyEventTimeConverter;
        public WeeklyEventConverter(IWeeklyEventTimeConverter weeklyEventTimeConverter, ISubscriberConverter subscriberConverter, IEventTemplateConverter eventTemplateConverter, IChiefConverter chiefConverter)
            : base(subscriberConverter, eventTemplateConverter, chiefConverter)
        {
            WeeklyEventTimeConverter = weeklyEventTimeConverter ?? throw new ArgumentNullException(nameof(weeklyEventTimeConverter));
        }
        public override WeeklyEvent ConvertToEntity(WeeklyEventViewModel model)
        {
            WeeklyEvent result = base.ConvertToEntity(model);
            model.DateAndTime.ForEach(item => result.DateAndTime.Add(WeeklyEventTimeConverter.ConvertToEntity(item)));
            return result;
        }

        public override WeeklyEventViewModel ConvertToViewModel(WeeklyEvent entity)
        {
            WeeklyEventViewModel result = base.ConvertToViewModel(entity);
            entity.DateAndTime.ForEach(item => result.DateAndTime.Add(WeeklyEventTimeConverter.ConvertToViewModel(item)));
            return result;
        }
    }
}
