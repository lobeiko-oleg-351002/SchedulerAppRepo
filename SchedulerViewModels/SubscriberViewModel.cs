using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels
{
    public class SubscriberViewModel : ViewModel
    {
        public bool IsConfirmed { get; set; }

        public StudentViewModel StudentViewModel { get; set; }
    }
}
