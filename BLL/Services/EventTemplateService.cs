using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EventTemplateService : Service<EventTemplate, EventTemplateViewModel, EventTemplateCreateModel>, IEventTemplateService
    {
        public EventTemplateService(IEventTemplateRepository eventTemplateRepository, IEventTemplateConverter eventTemplateConverter) : base(eventTemplateRepository, eventTemplateConverter)
        {

        }
    }
}
