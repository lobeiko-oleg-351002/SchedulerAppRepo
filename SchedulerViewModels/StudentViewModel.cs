using SchedulerModels;
using System;

namespace SchedulerViewModels
{
    public class StudentViewModel : ViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
