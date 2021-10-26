using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("SingleEvent")]
    public class SingleEvent : Event
    {
        [Required]
        public DateTime DateAndTime { get; set; }
    }
}
