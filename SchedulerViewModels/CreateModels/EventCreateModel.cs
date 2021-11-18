using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels.CreateModels
{
    public class EventCreateModel : CreateModel
    {
        public EventTemplateCreateModel EventTemplateCreateModel { get; set; }
        public ChiefViewModel ChiefViewModel { get; set; }
    }
}
