using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModels
{
    public class Event : EventTemplate
    {
        public DateTime DateAndTime { get; set; }

        public int SubscriberLib_id { get; set; }

        public Event()
        {

        }
    }
}
