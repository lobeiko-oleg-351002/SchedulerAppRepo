using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exceptions
{
    public class DalDeleteException : DalException
    {
        public DalDeleteException(string message) : base("Failed to delete an entity: " + message)
        {

        }
    }
}
