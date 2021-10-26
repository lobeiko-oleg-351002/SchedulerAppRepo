using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters.Interface
{
    public interface IWeeklyEventConverter : IEventConverter<WeeklyEvent, WeeklyEventViewModel>
    {

    }
}
