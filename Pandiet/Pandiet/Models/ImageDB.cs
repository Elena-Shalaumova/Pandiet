using System;
using System.Collections.Generic;
using System.Text;

namespace Pandiet.Models
{
    internal class ImageDB
    {
        public int ID { get; set; }
        public int GoalID { get; set; }
        public int DishID { get; set; }
        public string Image { get; set; }
    }
}
