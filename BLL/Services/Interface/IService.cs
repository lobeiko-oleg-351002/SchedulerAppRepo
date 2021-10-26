using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interface
{
    public interface IService<TEntity>
        where TEntity : ViewModel
    {
        void Create(TEntity entity);

        List<TEntity> GetAll();

        TEntity Get(Guid id);

        void Delete(Guid id);

        void Update(TEntity entity);
    }
}
