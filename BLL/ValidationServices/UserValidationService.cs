using BLL.Exceptions;
using BLL.ValidationServices.Interface;
using SchedulerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ValidationServices
{
    public class UserValidationService : IUserValidationService
    {
        public void ValidateNewUser(Student user)
        {
            if (user == null)
            {
                throw new UserValidationException("User is null");
            }

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Email))
            {
                throw new UserValidationException("User info is incomplete");
            }

            if (user.Role == null)
            {
                throw new UserValidationException("Role is not set");
            }

            if (user.Name == "totalit")
            {
                throw new UserValidationException("Error in BLL");
            }
        }
    }
}
