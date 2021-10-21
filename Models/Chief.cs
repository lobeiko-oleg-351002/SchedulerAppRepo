﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModels
{
    public class Chief : Student
    {
        [Required]
        public string Profile { get; set; }

        public List<Student> Students { get; set; }

        public List<EventTemplate> EventTemplates { get; set; }
    }
}
