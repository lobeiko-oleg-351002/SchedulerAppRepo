﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class NoElementsException : DalException
    {
        public NoElementsException() : base("No elements in Database")
        {

        }
    }
}
