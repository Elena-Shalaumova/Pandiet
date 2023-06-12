using System;
using System.Collections.Generic;
using System.Text;

namespace Pandiet.Models
{
    internal class Goal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GoalMode { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
