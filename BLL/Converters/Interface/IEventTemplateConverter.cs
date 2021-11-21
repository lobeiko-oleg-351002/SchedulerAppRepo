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
    public interface IEventTemplateConverter : IConverter<EventTemplateCreateModel, EventTemplateViewModel, EventTemplate>
    {

    }
}
