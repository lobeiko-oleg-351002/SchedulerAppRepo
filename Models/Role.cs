using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerModels
{
    public class Role : Entity
    {
        [Required]
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
