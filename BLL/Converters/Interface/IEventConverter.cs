using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters.Interface
{
    public interface IEventConverter<TEvent, UEvent, YEvent> : IConverter<TEvent, UEvent, YEvent>
        where TEvent : EventCreateModel
        where UEvent : EventViewModel
        where YEvent : Event
    {

    }
}
