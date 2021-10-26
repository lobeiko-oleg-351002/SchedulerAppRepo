using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IEventService<TEvent> : IService<TEvent>
        where TEvent : EventViewModel
    {
        public void AddSubscriberToEvent(Student student, TEvent evnt);
    }
}
