using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IService<TEntity, UEntity>
        where TEntity : ViewModel
        where UEntity : CreateModel
    {
        TEntity Create(UEntity entity);

        List<TEntity> GetAll();

        TEntity Get(Guid id);

        void Delete(Guid id);

        TEntity Update(UEntity entity);
    }
}
