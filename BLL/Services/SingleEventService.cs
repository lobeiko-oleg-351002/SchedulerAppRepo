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
    public class SingleEventService : EventService<SingleEvent, SingleEventViewModel, SingleEventCreateModel>, ISingleEventService
    {
        public SingleEventService(ISingleEventRepository singleEventRepository, ISubscriberService subscriberService, ISingleEventConverter singleEventConverter) : base(singleEventRepository, subscriberService, singleEventConverter)
        {

        }
    }
}
