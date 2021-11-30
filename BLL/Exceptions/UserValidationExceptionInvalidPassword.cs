using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class UserValidationExceptionInvalidPassword : UserValidationException
    {
        public UserValidationExceptionInvalidPassword(string message) : base("Invalid Password: " + message)
        {

        }
    }
}
