﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourplanner.Models
{
    internal class TaskModel
    {
        public string Name { get; set; } = "";
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
    }
}
