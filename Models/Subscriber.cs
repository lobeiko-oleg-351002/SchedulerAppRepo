using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModels
{
    public class Subscriber : Follower
    {
        public bool isConfirmed { get; set; }

        public Subscriber()
        {

        }
    }
}
