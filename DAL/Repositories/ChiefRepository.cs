using DAL.Exceptions;
using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Chief>> GetByProfileDescription(string tag)
        {
            _logMessageManager.LogCustomMessage("GetByProfileDescription: " + tag);
            var elements = await _context.Set<Chief>().AsQueryable().Where(e => e.Profile.Contains(tag)).ToListAsync();
            if (elements.Any())
            {
                _logMessageManager.LogSuccess();
                return elements.ToList();
            }
            var ex = new NoElementsException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }

        public override async Task<Chief> Create(Chief entity)
        {
            try
            {
                _logMessageManager.LogEntityCreation(entity);
                entity.Role = await _context.Roles.FirstOrDefaultAsync(role => role.Id == entity.Role.Id);
                var result = await _context.Set<Chief>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch(Exception ex)
            {
                _logMessageManager.LogFailure(ex.Message);
                throw new DalCreateException(ex.Message);
            }
        }
    }
}
