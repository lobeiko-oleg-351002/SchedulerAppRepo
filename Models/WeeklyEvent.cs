using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    public class WeeklyEvent : Event
    {
        [Required]
        public List<WeeklyEventTime> DateAndTime { get; set; }
    }
}
