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
    public class WeeklyEventConverter : EventConverter<WeeklyEventCreateModel, WeeklyEventViewModel, WeeklyEvent>, IWeeklyEventConverter
    {
        private readonly IWeeklyEventTimeConverter _weeklyEventTimeConverter;
        public WeeklyEventConverter(IWeeklyEventTimeConverter weeklyEventTimeConverter, ISubscriberConverter subscriberConverter, IEventTemplateConverter eventTemplateConverter, 
            IChiefConverter chiefConverter, IEventTemplateRepository eventTemplateRepository, IChiefRepository chiefRepository)
            : base(subscriberConverter, eventTemplateConverter, chiefConverter, eventTemplateRepository, chiefRepository)
        {
            _weeklyEventTimeConverter = weeklyEventTimeConverter ?? throw new ArgumentNullException(nameof(weeklyEventTimeConverter));
        }
        public override WeeklyEvent ConvertToEntity(WeeklyEventCreateModel model)
        {
            WeeklyEvent result = base.ConvertToEntity(model);
            model.DateAndTime.ForEach(item => result.DateAndTime.Add(_weeklyEventTimeConverter.ConvertToEntity(item)));
            return result;
        }

        public override WeeklyEventViewModel ConvertToViewModel(WeeklyEvent entity)
        {
            WeeklyEventViewModel result = base.ConvertToViewModel(entity);
            entity.DateAndTime.ForEach(item => result.DateAndTime.Add(_weeklyEventTimeConverter.ConvertToViewModel(item)));
            return result;
        }
    }
}
