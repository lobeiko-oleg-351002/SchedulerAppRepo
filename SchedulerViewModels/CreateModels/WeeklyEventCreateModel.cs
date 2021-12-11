using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels.CreateModels
{
    public class WeeklyEventCreateModel : EventCreateModel
    {
        public List<WeeklyEventTimeCreateModel> DateAndTime { get; set; }

        public WeeklyEventCreateModel()
        {
            DateAndTime = new List<WeeklyEventTimeCreateModel>();
        }
    }
}
