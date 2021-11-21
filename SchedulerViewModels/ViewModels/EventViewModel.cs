using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels
{
    public class EventViewModel : ViewModel
    {
        public EventTemplateViewModel EventTemplateViewModel { get; set; }
        public List<SubscriberViewModel> Subscribers { get; set; }
        public ChiefViewModel ChiefViewModel { get; set; }
    }
}
