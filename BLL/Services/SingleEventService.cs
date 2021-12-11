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
    public class SingleEventService : EventService<SingleEvent, SingleEventViewModel, SingleEventCreateModel>, ISingleEventService, IEventFilter<SingleEventViewModel>
    {
        public SingleEventService(ISingleEventRepository singleEventRepository, ISubscriberService subscriberService, ISingleEventConverter singleEventConverter) : base(singleEventRepository, subscriberService, singleEventConverter)
        {

        }

        public List<SingleEventViewModel> GetByChiefIdAndDateTimeRange(Guid? chiefId, DateTimeRange range)
        {
            var query = _repository.GetAll();

            query = GetByChiefId(chiefId, query);

            if (range != null)
            {
                query = from entity in query
                        where (entity.DateAndTime >= range.Start) && (entity.DateAndTime <= range.End)
                        select entity;
            }

            return query.Select(_converter.ConvertToViewModel).ToList();
        }
    }
}
