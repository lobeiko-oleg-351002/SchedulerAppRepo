using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationServices.Interface
{
    public interface IUserValidationService
    {
        void ValidateNewUser(Student user);

        void ValidateNameAndPassword(string name, string password);
    }
}
