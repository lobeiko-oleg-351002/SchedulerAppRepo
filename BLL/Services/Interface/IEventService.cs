using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using SchedulerViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IEventService<TEntity, UEntity> : IService<TEntity, UEntity>
        where TEntity : EventViewModel
        where UEntity : EventCreateModel
    {
        public void AddSubscriberToEvent(Student student, UEntity evnt);
    }
}
