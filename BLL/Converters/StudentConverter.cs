using BLL.Converters.Interface;
using SchedulerModels;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class StudentConverter : IStudentConverter
    {
        public Student ConvertToEntity(StudentViewModel model)
        {
            Student result = new Student
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                Name = model.Name
            };
            return result;
        }

        public StudentViewModel ConvertToViewModel(Student entity)
        {
            StudentViewModel result = new StudentViewModel
            {
                Id = entity.Id,
                Email = entity.Email,
                Password = entity.Password,
                Name = entity.Name
            };
            return result;
        }
    }
}
