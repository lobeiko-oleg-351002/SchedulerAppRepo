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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchedulerDbContext context, ILogMessageManager<Student> logMessageManager) : base(context, logMessageManager)
        {

        }

        public async Task<Student> GetByNameAndPassword(string name, string password)
        {
            _logMessageManager.LogCustomMessage("GetByNameAndPassword. Name: " + name + " Password: " + password);
            var entity = await _context.Students.Include(role => role.Role).FirstOrDefaultAsync(e => (e.Name == name) && (e.Password == password));
            if (entity == null)
            {
                var ex = new ItemNotFoundException();
                _logMessageManager.LogFailure(ex.Message);
                throw ex;
            }
            _logMessageManager.LogSuccess();
            return entity;
        }

        public override async Task<Student> Get(Guid id)
        {
            _logMessageManager.LogGet(id);
            Student student = await _context.Students.Include(role => role.Role).FirstOrDefaultAsync(user => user.Id == id);
            if (student == null)
            {
                var ex = new ItemNotFoundException();
                _logMessageManager.LogFailure(ex.Message);
                throw ex;
            }
            _logMessageManager.LogSuccess();
            return student;
        }

        public override async Task<List<Student>> GetAll()
        {           
            _logMessageManager.LogGetAll();
            var elements = _context.Students.Include(role => role.Role).AsQueryable();
            if (elements.Any())
            {
                _logMessageManager.LogSuccess();
                return await elements.ToListAsync();
            }
            var ex = new NoElementsException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }
    }
}
