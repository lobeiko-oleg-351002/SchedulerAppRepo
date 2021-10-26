using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IRepository<TEntity>
        where TEntity : Entity

    {
        TEntity Create(TEntity entity);

        List<TEntity> GetAll();

        TEntity Get(Guid id);

        void Delete(Guid id);

        TEntity Update(TEntity entity);
    }
}
