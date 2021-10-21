using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    public abstract class Entity
    {
        [Key, Required]
        public Guid Id { get; set; }
    }
}
