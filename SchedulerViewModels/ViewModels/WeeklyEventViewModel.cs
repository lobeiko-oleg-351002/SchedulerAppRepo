using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels
{
    public class WeeklyEventViewModel : EventViewModel
    {
        public List<WeeklyEventTimeViewModel> DateAndTime { get; set; }

        public WeeklyEventViewModel()
        {
            DateAndTime = new List<WeeklyEventTimeViewModel>();
        }
    }
}
