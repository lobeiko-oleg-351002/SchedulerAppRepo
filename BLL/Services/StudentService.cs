using BLL.Converters;
using BLL.Converters.Interface;
using BLL.Services.Interface;
using BLL.ValidationServices.Interface;
using DAL.Repositories.Interface;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<StudentService> Logger;
        public StudentService(IStudentRepository studentRepository, IStudentConverter studentConverter, IUserValidationService userValidationService, ILogger<StudentService> logger) 
            : base(studentRepository, studentConverter)
        {
            UserValidationService = userValidationService;
            Logger = logger;
        }

        public StudentViewModel GetByNameAndPassword(string name, string password)
        {
            try
            {
                return Converter.ConvertToViewModel(((IStudentRepository)Repository).GetByNameAndPassword(name, password));
            }
            catch
            {
                Logger.LogError("GetByNameAndPassword: error.");
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
                Logger.LogError("Create: error.");
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
                Logger.LogError("Update: error.");
                throw;
            }
        }
    }
}
