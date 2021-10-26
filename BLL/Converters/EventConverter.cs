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
    public class EventConverter<TEvent, UEvent> : IEventConverter<TEvent, UEvent>
        where TEvent : Event, new()
        where UEvent : EventViewModel, new()
    {
        private readonly ISubscriberConverter SubscriberConverter;
        private readonly IEventTemplateConverter EventTemplateConverter;
        private readonly IChiefConverter ChiefConverter;
        public EventConverter(ISubscriberConverter subscriberConverter, IEventTemplateConverter eventTemplateConverter, IChiefConverter chiefConverter)
        {
            SubscriberConverter = subscriberConverter ?? throw new ArgumentNullException(nameof(subscriberConverter));
            EventTemplateConverter = eventTemplateConverter ?? throw new ArgumentNullException(nameof(eventTemplateConverter));
            ChiefConverter = chiefConverter ?? throw new ArgumentNullException(nameof(chiefConverter));
        }
        public virtual TEvent ConvertToEntity(UEvent model)
        {
            TEvent result = new();
            result.Id = model.Id;
            model.Subscribers.ForEach(item => result.Subscribers.Add(SubscriberConverter.ConvertToEntity(item)));
            result.EventTemplate = EventTemplateConverter.ConvertToEntity(model.EventTemplateViewModel);
            result.Chief = ChiefConverter.ConvertToEntity(model.ChiefViewModel);

            return result;
        }

        public virtual UEvent ConvertToViewModel(TEvent entity)
        {
            UEvent result = new();
            result.Id = entity.Id;
            entity.Subscribers.ForEach(item => result.Subscribers.Add(SubscriberConverter.ConvertToViewModel(item)));
            result.EventTemplateViewModel = EventTemplateConverter.ConvertToViewModel(entity.EventTemplate);
            result.ChiefViewModel = ChiefConverter.ConvertToViewModel(entity.Chief);

            return result;
        }
    }
}
