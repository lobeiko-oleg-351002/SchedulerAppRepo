using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    [Table("Role")]
    public class Role : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}
