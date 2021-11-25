using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerViewModels.CreateModels
{
    public class ChiefCreateModel : StudentCreateModel
    {
        public string Profile { get; set; }

        public ChiefCreateModel()
        {

        }

        public ChiefCreateModel(StudentCreateModel baseObject)
        {
            this.Id = baseObject.Id;
            this.Email = baseObject.Email;
            this.Name = baseObject.Name;
            this.Password = baseObject.Password;
            this.Role = baseObject.Role;
        }
    }
}
