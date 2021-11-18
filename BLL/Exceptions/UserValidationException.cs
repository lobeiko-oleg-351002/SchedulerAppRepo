using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class UserValidationException : BllException
    {
        public UserValidationException(string message) : base(message)
        {

        }
    }
}
