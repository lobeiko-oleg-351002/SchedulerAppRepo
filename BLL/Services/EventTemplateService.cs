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
    public class EventTemplateService : Service<EventTemplate, EventTemplateViewModel>, IEventTemplateService
    {
        public EventTemplateService(IEventTemplateRepository eventTemplateRepository, IEventTemplateConverter eventTemplateConverter) : base(eventTemplateRepository, eventTemplateConverter)
        {

        }
    }
}
