using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("Subscriber")]
    public class Subscriber : Entity
    {
        [Required]
        public bool IsConfirmed { get; set; }

        public virtual Event Event { get; set; }

        public virtual Student Student {get; set;}
    }
}
