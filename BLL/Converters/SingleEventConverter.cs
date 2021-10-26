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
    public class SingleEventConverter : EventConverter<SingleEvent, SingleEventViewModel>, ISingleEventConverter
    {
        public SingleEventConverter(ISubscriberConverter subscriberConverter, IEventTemplateConverter eventTemplateConverter, IChiefConverter chiefConverter) 
            : base(subscriberConverter, eventTemplateConverter, chiefConverter)
        {
            
        }
        public override SingleEvent ConvertToEntity(SingleEventViewModel model)
        {
            SingleEvent result = base.ConvertToEntity(model);
            result.DateAndTime = model.DateAndTime;

            return result;
        }

        public override SingleEventViewModel ConvertToViewModel(SingleEvent entity)
        {
            SingleEventViewModel result = base.ConvertToViewModel(entity);
            result.DateAndTime = entity.DateAndTime;

            return result;
        }
    }
}
