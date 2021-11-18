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

        public Student GetByNameAndPassword(string name, string password)
        {
            _logMessageManager.LogCustomMessage("GetByNameAndPassword. Name: " + name + " Password: " + password);
            var entity = _context.Students.Include(role => role.Role).FirstOrDefault(e => (e.Name == name) && (e.Password == password));
            if (entity == null)
            {
                var ex = new ItemNotFoundException();
                _logMessageManager.LogFailure(ex.Message);
                throw ex;
            }
            _logMessageManager.LogSuccess();
            return entity;
        }

        public override Student Get(Guid id)
        {
            _logMessageManager.LogGet(id);
            Student student = _context.Students.Include(role => role.Role).FirstOrDefault(user => user.Id == id);
            if (student == null)
            {
                var ex = new ItemNotFoundException();
                _logMessageManager.LogFailure(ex.Message);
                throw ex;
            }
            _logMessageManager.LogSuccess();
            return student;
        }

        public override List<Student> GetAll()
        {           
            _logMessageManager.LogGetAll();
            var elements = _context.Students.Include(role => role.Role).Select(e => e);
            if (elements.Any())
            {
                _logMessageManager.LogSuccess();
                return elements.ToList();
            }
            var ex = new NoElementsException();
            _logMessageManager.LogFailure(ex.Message);
            throw ex;
        }
    }
}
