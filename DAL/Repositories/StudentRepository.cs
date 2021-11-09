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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchedulerDbContext context) : base(context)
        {

        }

        public Student GetByNameAndPassword(string name, string password)
        {
            var entity = Context.Set<Student>().FirstOrDefault(e => (e.Name == name) && (e.Password == password));
            return entity ?? throw new ItemNotFoundException();
        }
    }
}
