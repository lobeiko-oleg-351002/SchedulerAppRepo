using DAL.Exceptions;
using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Microsoft.Extensions.Logging;
using SchedulerMigrations.Data;
using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly SchedulerDbContext _context;
        protected readonly ILogMessageManager<TEntity> _logMessageManager;
        
        public Repository(SchedulerDbContext context, ILogMessageManager<TEntity> logMessageManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logMessageManager = logMessageManager;
        }

        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                _logMessageManager.LogEntityCreation(entity);
                var result = _context.Set<TEntity>().Add(entity).Entity;
                _context.SaveChanges();
                _logMessageManager.LogSuccess();
                return result;
            }
            catch(Exception ex)
            {
                _logMessageManager.LogFailure(ex.Message);
                throw new DalCreateException(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _logMessageManager.LogDelete(id);
                var entity = _context.Set<TEntity>().Single(e => e.Id == id);
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();
                _logMessageManager.LogSuccess();
            }
            catch(Exception ex)
            {
                _logMessageManager.LogFailure(ex.Message);
                throw new DalDeleteException(ex.Message);
            }
        }

        public virtual TEntity Get(Guid id)
        {
            _logMessageManager.LogGet(id);
            var entity = _context.Set<TEntity>().FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                _logMessageManager.LogSuccess();
                return entity;
            }
            var ex = new ItemNotFoundException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }

        public virtual List<TEntity> GetAll()
        {
            _logMessageManager.LogGetAll();
            var elements = _context.Set<TEntity>().Select(e => e);
            if (elements.Any())
            {
                _logMessageManager.LogSuccess();
                return elements.ToList();
            }
            var ex = new NoElementsException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }

        public TEntity Update(TEntity entity)
        {
            _logMessageManager.LogEntityUpdate(entity);
            var Entity = _context.Set<TEntity>().Find(entity.Id);
            if (Entity != null)
            {
                _context.Entry(Entity).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                _logMessageManager.LogSuccess();
                return Entity;
            }
            var ex = new ItemNotFoundException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }
    }
}
