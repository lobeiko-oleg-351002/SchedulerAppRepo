using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class UserValidationExceptionInvalidName : UserValidationException
    {
        public UserValidationExceptionInvalidName(string message) : base("Invalid name: " + message)
        {

        }
    }
}
