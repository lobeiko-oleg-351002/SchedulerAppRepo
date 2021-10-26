using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EventService<TEvent, UEvent> : Service<TEvent, UEvent>, IEventService<UEvent>
        where TEvent : Event
        where UEvent : EventViewModel
    {
        private readonly ISubscriberService SubscriberService;
        public EventService(IEventRepository<TEvent> repository, ISubscriberService subscriberService, IEventConverter<TEvent, UEvent> eventConverter) : base(repository, eventConverter)
        {
            SubscriberService = subscriberService ?? throw new ArgumentNullException(nameof(SubscriberService));
        }

        public void AddSubscriberToEvent(Student student, UEvent evnt)
        {
            var subscriber = CreateSubscriber(student, evnt);
            evnt.Subscribers.Add(subscriber);
            Repository.Update(Converter.ConvertToEntity(evnt));
        }

        protected SubscriberViewModel CreateSubscriber(Student student, UEvent evnt)
        {
            //Subscriber subscriber = new Subscriber();
            //subscriber.Event = evnt;
            //subscriber.Student = student;
            //SubscriberService.Create(subscriber);
            throw new NotImplementedException();
        }
    }
}
