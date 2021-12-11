using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("WeeklyEvent")]
    public class WeeklyEvent : Event
    {
        [Required]
        public virtual List<WeeklyEventTime> DateAndTime { get; set; }

        public WeeklyEvent()
        {
            DateAndTime = new List<WeeklyEventTime>();
        }
    }
}
