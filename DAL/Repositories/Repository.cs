using DAL.Exceptions;
using DAL.Repositories.Interface;
using SchedulerMigrations.Data;
using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly SchedulerDbContext Context;
        public Repository(SchedulerDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TEntity Create(TEntity entity)
        {
            var result = Context.Set<TEntity>().Add(entity).Entity;
            Context.SaveChanges();
            return result;
        }

        public void Delete(Guid id)
        {
            var entity = Context.Set<TEntity>().Single(e => e.Id == id);
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
            var entity = Context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            return entity ?? throw new ItemNotFoundException();
        }

        public List<TEntity> GetAll()
        {
            var elements = Context.Set<TEntity>().Select(e => e);
            if (elements.Any())
            {
                return elements.ToList();
            }
            else throw new NoElementsException();
        }

        public TEntity Update(TEntity entity)
        {
            var Entity = Context.Set<TEntity>().Find(entity.Id);
            if (Entity != null)
            {
                Context.Entry(Entity).CurrentValues.SetValues(entity);
                Context.SaveChanges();
                return Entity;
            }
            else throw new ItemNotFoundException();
        }
    }
}
