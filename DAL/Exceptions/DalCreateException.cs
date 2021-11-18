using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class DalCreateException : DalException
    {
        public DalCreateException(string message) : base("Failed to create an entity: " + message)
        {

        }
    }
}
