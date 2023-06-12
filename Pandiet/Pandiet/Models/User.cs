using System;
using System.Collections.Generic;
using System.Text;

namespace Pandiet.Models
{
    internal class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateBirthday { get; set; }
        public int GenderID { get; set; }
        public double Weight { get; set; }
        public int DietModeID { get; set; }
        public int NotificationsMode { get; set; }
        public int ProfileModeID { get; set; }
        public int GoalID { get; set; }
        public int GoalProgress { get; set; }
        public int CategoryPeopleID { get; set; }

    }
}
