using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels.CreateModels
{
    public class EventCreateModel : CreateModel
    {
        public Guid EventTemplateId { get; set; }
        public Guid ChiefId { get; set; }
    }
}
