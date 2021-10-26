using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("Event")]
    public class Event : Entity
    {
        public EventTemplate EventTemplate { get; set; }
        public List<Subscriber> Subscribers { get; set; }

        public Chief Chief { get; set; }
    }
}
