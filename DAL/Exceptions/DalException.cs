﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class DalException : Exception
    {
        public DalException(string message) : base(message) { }
    }
}
