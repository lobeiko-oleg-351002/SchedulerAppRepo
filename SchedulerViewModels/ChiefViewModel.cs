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
            this.Id = base.Id;
            this.Email = baseObject.Email;
            this.Name = baseObject.Name;
            this.Password = baseObject.Password;
        }
    }
}
