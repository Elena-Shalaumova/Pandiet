using System;
using System.Collections.Generic;
using System.Text;

namespace Pandiet.Models
{
    internal class Dish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Squirrels { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public int Calories { get; set; }
        public int Sugar { get; set; }
        public string Description { get; set; }
        public string Recipe { get; set; }
        public int TimesOfDayID { get; set; }

    }
}
