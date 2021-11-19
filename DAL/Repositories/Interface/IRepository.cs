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
        Task<TEntity> Create(TEntity entity);

        Task<List<TEntity>> GetAll();

        Task<TEntity> Get(Guid id);

        void Delete(Guid id);

        Task<TEntity> Update(TEntity entity);
    }
}
