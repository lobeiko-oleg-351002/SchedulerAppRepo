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
    public class EventConverter<TEvent, UEvent, YEvent> : IEventConverter<TEvent, UEvent, YEvent>
        where TEvent : EventCreateModel, new()
        where UEvent : EventViewModel, new()
        where YEvent : Event, new()
    {
        private readonly ISubscriberConverter _subscriberConverter;
        private readonly IEventTemplateConverter _eventTemplateConverter;
        private readonly IChiefConverter _chiefConverter;
        private readonly IChiefRepository _chiefRepository;
        private readonly IEventTemplateRepository _eventTemplateRepository;
        public EventConverter(ISubscriberConverter subscriberConverter, IEventTemplateConverter eventTemplateConverter, IChiefConverter chiefConverter, IEventTemplateRepository eventTemplateRepository,
            IChiefRepository chiefRepository)
        {
            _subscriberConverter = subscriberConverter ?? throw new ArgumentNullException(nameof(subscriberConverter));
            _eventTemplateConverter = eventTemplateConverter ?? throw new ArgumentNullException(nameof(eventTemplateConverter));
            _chiefConverter = chiefConverter ?? throw new ArgumentNullException(nameof(chiefConverter));
            _chiefRepository = chiefRepository ?? throw new ArgumentNullException(nameof(chiefRepository));
            _eventTemplateRepository = eventTemplateRepository ?? throw new ArgumentNullException(nameof(eventTemplateRepository));
        }
        public virtual YEvent ConvertToEntity(TEvent model)
        {
            YEvent result = new();
            result.Id = model.Id;
            result.EventTemplate = _eventTemplateRepository.Get(model.EventTemplateId).Result;
            result.Chief = _chiefRepository.Get(model.ChiefId).Result;

            return result;
        }

        public virtual UEvent ConvertToViewModel(YEvent entity)
        {
            UEvent result = new();
            result.Id = entity.Id;
            entity.Subscribers.ForEach(item => result.Subscribers.Add(_subscriberConverter.ConvertToViewModel(item)));
            result.EventTemplateViewModel = _eventTemplateConverter.ConvertToViewModel(entity.EventTemplate);
            result.ChiefViewModel = _chiefConverter.ConvertToViewModel(entity.Chief);

            return result;
        }
    }
}
