using BLL.Converters.Interface;
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
    public class SingleEventConverter : EventConverter<SingleEventCreateModel, SingleEventViewModel, SingleEvent>, ISingleEventConverter
    {
        public SingleEventConverter(ISubscriberConverter subscriberConverter, IEventTemplateConverter eventTemplateConverter, IChiefConverter chiefConverter) 
            : base(subscriberConverter, eventTemplateConverter, chiefConverter)
        {
            
        }
        public override SingleEvent ConvertToEntity(SingleEventCreateModel model)
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
