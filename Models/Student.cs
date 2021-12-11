using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("Student")]
    public class Student : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual List<Subscriber> Subscribers { get; set; }

        public virtual List<Chief> Chiefs { get; set; }

        public virtual Role Role { get; set; }

    }
}
