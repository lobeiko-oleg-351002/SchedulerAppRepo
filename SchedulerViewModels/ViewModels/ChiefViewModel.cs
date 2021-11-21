using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels
{
    public class ChiefViewModel : StudentViewModel
    {
        public string Profile { get; set; }

        public ChiefViewModel()
        {

        }

        public ChiefViewModel(StudentViewModel baseObject)
        {
            this.Id = baseObject.Id;
            this.Name = baseObject.Name;
            this.Role = baseObject.Role;
        }
    }
}
