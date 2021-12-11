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
    public class EventService<TEvent, UEvent, YEvent> : Service<TEvent, UEvent, YEvent>, IEventService<UEvent, YEvent>
        where TEvent : Event
        where UEvent : EventViewModel
        where YEvent : EventCreateModel
    {
        private readonly ISubscriberService _subscriberService;
        public EventService(IEventRepository<TEvent> repository, ISubscriberService subscriberService, IEventConverter<YEvent, UEvent, TEvent> eventConverter) : base(repository, eventConverter)
        {
            _subscriberService = subscriberService ?? throw new ArgumentNullException(nameof(_subscriberService));
        }

        public void AddSubscriberToEvent(Student student, YEvent evnt)
        {
            var subscriber = CreateSubscriber(student, evnt);
            //evnt.Subscribers.Add(subscriber);
            //_repository.Update(_converter.ConvertToEntity(evnt));
            throw new NotImplementedException();
        }

        protected SubscriberViewModel CreateSubscriber(Student student, YEvent evnt)
        {
            //Subscriber subscriber = new Subscriber();
            //subscriber.Event = evnt;
            //subscriber.Student = student;
            //SubscriberService.Create(subscriber);
            throw new NotImplementedException();
        }

        protected IQueryable<TEvent> GetByChiefId(Guid? chiefId, IQueryable<TEvent> query)
        {
            if (chiefId != null)
            {
                query = from entity in query
                        where entity.Chief.Id == chiefId
                        select entity;
            }
            return query;
        }
    }
}
