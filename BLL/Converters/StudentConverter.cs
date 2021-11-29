using BLL.Converters.Interface;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public class StudentConverter : IStudentConverter
    {
        public Student ConvertToEntity(StudentCreateModel model)
        {
            if (model == null) throw new ArgumentNullException();
            Student result = new Student
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                Name = model.Name, 
                Role = model.Role
            };
            return result;
        }

        public StudentViewModel ConvertToViewModel(Student entity)
        {
            if (entity == null) throw new ArgumentNullException();
            StudentViewModel result = new StudentViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Role = entity.Role
            };
            return result;
        }
    }
}
