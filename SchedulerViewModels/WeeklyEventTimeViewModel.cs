﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels
{
    public class WeeklyEventTimeViewModel : ViewModel
    {
        public DateTime Time { get; set; }

        public List<DayOfWeekViewModel> DaysOfWeek { get; set; }
    }
}
