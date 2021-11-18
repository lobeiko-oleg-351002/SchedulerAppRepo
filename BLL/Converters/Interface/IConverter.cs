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
    public interface IConverter<TEntity, UEntity, YEntity>
        where TEntity : CreateModel
        where UEntity : ViewModel
        where YEntity : Entity
    {
        public UEntity ConvertToViewModel(YEntity entity);
        public YEntity ConvertToEntity(TEntity model);
    }
}
