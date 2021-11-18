using BLL.Converters;
using BLL.Converters.Interface;
using BLL.Exceptions;
using BLL.Services.Interface;
using BLL.ValidationServices.Interface;
using DAL.Exceptions;
using DAL.Repositories.Interface;
using Microsoft.Extensions.Logging;
using SchedulerModels;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService : Service<Student, StudentViewModel, StudentCreateModel>, IStudentService
    {
        private readonly IUserValidationService _userValidationService;
        public StudentService(IStudentRepository studentRepository, IStudentConverter studentConverter, IUserValidationService userValidationService) 
            : base(studentRepository, studentConverter)
        {
            _userValidationService = userValidationService;
        }

        public StudentViewModel GetByNameAndPassword(string name, string password)
        {
            _userValidationService.ValidateNameAndPassword(name, password);
            try
            {
                return _converter.ConvertToViewModel(((IStudentRepository)_repository).GetByNameAndPassword(name, password));
            }
            catch (ItemNotFoundException)
            {
                throw new UserNotFoundException();
            }
        }

        public override StudentViewModel Create(StudentCreateModel entity)
        {
            _userValidationService.ValidateNewUser(_converter.ConvertToEntity(entity));
            return base.Create(entity);
        }

        public override StudentViewModel Update(StudentCreateModel entity)
        {
            _userValidationService.ValidateNewUser(_converter.ConvertToEntity(entity));
           return  base.Update(entity);
        }
    }
}
