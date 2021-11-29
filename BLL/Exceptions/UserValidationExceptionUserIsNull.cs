﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class UserValidationExceptionUserIsNull : UserValidationException
    {
        public UserValidationExceptionUserIsNull() : base("User is null")
        {

        }
    }
}
