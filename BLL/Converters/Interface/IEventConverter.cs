using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters.Interface
{
    public interface IEventConverter<TEvent, UEvent> : IConverter<TEvent, UEvent>
        where TEvent : Event
        where UEvent : EventViewModel
    {

    }
}
