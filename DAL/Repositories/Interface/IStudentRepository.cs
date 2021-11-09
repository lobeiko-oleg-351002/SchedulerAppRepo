using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        public Student GetByNameAndPassword(string name, string password);
    }
}
