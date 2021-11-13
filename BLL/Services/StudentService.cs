using BLL.Converters;
using BLL.Converters.Interface;
using BLL.Services.Interface;
using BLL.ValidationServices.Interface;
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
        private readonly IUserValidationService UserValidationService;
        public StudentService(IStudentRepository studentRepository, IStudentConverter studentConverter, IUserValidationService userValidationService) : base(studentRepository, studentConverter)
        {
            UserValidationService = userValidationService;
        }

        public StudentViewModel GetByNameAndPassword(string name, string password)
        {
            try
            {
                return Converter.ConvertToViewModel(((IStudentRepository)Repository).GetByNameAndPassword(name, password));
            }
            catch
            {
                throw;
            }
        }

        public override void Create(StudentViewModel entity)
        {
            try
            {
                UserValidationService.ValidateNewUser(Converter.ConvertToEntity(entity));
                base.Create(entity);
            }
            catch
            {
                throw;
            }
        }

        public override void Update(StudentViewModel entity)
        {
            try
            {
                UserValidationService.ValidateNewUser(Converter.ConvertToEntity(entity));
                base.Update(entity);
            }
            catch
            {
                throw;
            }
        }
    }
}
