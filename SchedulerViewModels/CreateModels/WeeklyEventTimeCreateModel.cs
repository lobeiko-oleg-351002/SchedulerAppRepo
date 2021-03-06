using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels.CreateModels
{
    public class WeeklyEventTimeCreateModel : CreateModel
    {
        public DateTime Time { get; set; }

        public List<Guid> DaysOfWeek { get; set; }

        public WeeklyEventTimeCreateModel()
        {
            DaysOfWeek = new List<Guid>();
        }
    }
}
