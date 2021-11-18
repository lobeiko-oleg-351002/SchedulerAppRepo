using DAL.Exceptions;
using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using SchedulerMigrations.Data;
using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ChiefRepository : Repository<Chief>, IChiefRepository
    {
        public ChiefRepository(SchedulerDbContext context, ILogMessageManager<Chief> logMessageManager) : base(context, logMessageManager)
        {
            
        }

        public List<Chief> GetByProfileDescription(string tag)
        {
            _logMessageManager.LogCustomMessage("GetByProfileDescription: " + tag);
            var elements = _context.Set<Chief>().Where(e => e.Profile.Contains(tag));
            if (elements.Any())
            {
                _logMessageManager.LogSuccess();
                return elements.ToList();
            }
            var ex = new NoElementsException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }

        public override Chief Create(Chief entity)
        {
            try
            {
                _logMessageManager.LogEntityCreation(entity);
                entity.Role = _context.Roles.FirstOrDefault(role => role.Id == entity.Role.Id);
                var result = _context.Set<Chief>().Add(entity).Entity;
                _context.SaveChanges();
                return result;
            }
            catch(Exception ex)
            {
                _logMessageManager.LogFailure(ex.Message);
                throw new DalCreateException(ex.Message);
            }
        }
    }
}
