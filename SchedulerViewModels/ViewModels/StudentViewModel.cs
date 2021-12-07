using SchedulerModels;
using System;

namespace SchedulerViewModels
{
    public class StudentViewModel : ViewModel
    {
        public string Name { get; set; }

        public Role Role { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            var model = (StudentViewModel)obj;
            return model.Id.Equals(Id) && (model.Name == Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}
