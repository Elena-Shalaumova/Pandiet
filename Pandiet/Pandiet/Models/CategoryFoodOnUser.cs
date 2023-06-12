using System;
using System.Collections.Generic;
using System.Text;

namespace Pandiet.Models
{
    internal class CategoryFoodOnUser
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CategoryFoodID { get; set; }
        public bool Status { get; set; }
    }
}
