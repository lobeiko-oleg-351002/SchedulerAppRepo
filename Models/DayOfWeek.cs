using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("DayOfWeek")]
    public class DayOfWeek : Entity
    {
        [Required]
        public string Name { get; set; }

        public List<WeeklyEventTime> WeeklyEventTimes { get; set; }
    }
}
