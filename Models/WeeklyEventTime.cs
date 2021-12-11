using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("WeeklyEventTime")]
    public class WeeklyEventTime : Entity
    {
        [Required]
        public DateTime Time { get; set; }

        public virtual List<DayOfWeek> DaysOfWeek { get; set; }

        public WeeklyEventTime()
        {
            DaysOfWeek = new List<DayOfWeek>();
        }
    }
}
