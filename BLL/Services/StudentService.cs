using BLL.Converters;
using BLL.Converters.Interface;
using BLL.Services.Interface;
using DAL.Repositories.Interface;
using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService : Service<Student, StudentViewModel>, IStudentService
    {
        public StudentService(IStudentRepository studentRepository, IStudentConverter studentConverter) : base(studentRepository, studentConverter)
        {

        }

        public StudentViewModel GetByNameAndPassword(string name, string password)
        {
            return Converter.ConvertToViewModel(((IStudentRepository)Repository).GetByNameAndPassword(name, password));
        }
    }
}
