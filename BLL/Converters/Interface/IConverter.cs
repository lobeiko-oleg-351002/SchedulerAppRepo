using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters.Interface
{
    public interface IConverter<TEntity, UEntity>
        where TEntity : Entity
        where UEntity : ViewModel
    {
        public UEntity ConvertToViewModel(TEntity entity);
        public TEntity ConvertToEntity(UEntity model);
    }
}
