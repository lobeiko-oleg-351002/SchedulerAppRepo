using SchedulerViewModels;
using SchedulerViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IEventFilter<TEntity>
        where TEntity : ViewModel
    {
        public List<TEntity> GetByChiefIdAndDateTimeRange(Guid? chiefId, DateTimeRange range);
    }
}
