using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions
{
    public class BllException : Exception
    {
        public BllException(string message) : base(message) { }
    }
}
