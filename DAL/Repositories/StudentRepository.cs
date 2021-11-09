using DAL.Exceptions;
using DAL.Repositories.Interface;
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
        public StudentRepository(SchedulerDbContext context) : base(context)
        {

        }

        public Student GetByNameAndPassword(string name, string password)
        {
            var entity = Context.Students.Include(role => role.Role).FirstOrDefault(e => (e.Name == name) && (e.Password == password));
            return entity ?? throw new ItemNotFoundException();
        }

        public override Student Get(Guid id)
        {
            Student student = Context.Students.Include(role => role.Role).FirstOrDefault(user => user.Id == id);
            return student;
        }

        public override List<Student> GetAll()
        {
            var elements = Context.Students.Include(role => role.Role).Select(e => e);
            if (elements.Any())
            {
                return elements.ToList();
            }
            else throw new NoElementsException();
        }
    }
}
