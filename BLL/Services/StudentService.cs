using BLL.Caching;
using BLL.Caching.Base;
using BLL.Converters;
using BLL.Converters.Interface;
using BLL.Exceptions;
using BLL.Services.Interface;
using BLL.ValidationServices.Interface;
using DAL.Exceptions;
using DAL.Repositories.Interface;
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
        private readonly ICacheService _cacheService;
        public StudentService(IStudentRepository studentRepository, IStudentConverter studentConverter, IUserValidationService userValidationService, ICacheService cacheService) 
            : base(studentRepository, studentConverter)
        {
            _userValidationService = userValidationService;
            _cacheService = cacheService;
        }

        public async Task<StudentViewModel> GetByNameAndPassword(string name, string password)
        {
            _userValidationService.ValidateNameAndPassword(name, password);
            try
            {
                var entity = await ((IStudentRepository)_repository).GetByNameAndPassword(name, password);
                return _converter.ConvertToViewModel(entity);
            }
            catch (ItemNotFoundException)
            {
                throw new UserNotFoundException();
            }
        }

        public override async Task<StudentViewModel> Create(StudentCreateModel entity)
        {
            _userValidationService.ValidateNewUser(_converter.ConvertToEntity(entity));
            var result =  await base.Create(entity);
            _cacheService.Set(GetKey(result.Id.ToString()), result);
            return result;
        }

        public override async Task<StudentViewModel> Update(StudentCreateModel entity)
        {
            _userValidationService.ValidateNewUser(_converter.ConvertToEntity(entity));
           return await base.Update(entity);
        }

        public override async Task<StudentViewModel> Get(Guid id)
        {
            StudentViewModel user = _cacheService.Get<StudentViewModel>(GetKey(id.ToString()));
            if (user == null)
            {
                user = await base.Get(id);
                _cacheService.Set(GetKey(user.Id.ToString()), user);
            }
            return user;
        }
    }
}
