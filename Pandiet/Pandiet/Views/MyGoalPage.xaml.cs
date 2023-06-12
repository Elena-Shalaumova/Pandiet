using Pandiet.Models;
using Pandiet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pandiet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyGoalPage : ContentPage
    {
        DataBase db = new DataBase();
        public MyGoalPage(int userID)
        {
            InitializeComponent();
            BindingContext = new GoalsViewModel(userID) { Navigation = this.Navigation };
            db.GetUser(userID);
            db.GetUserGoal(db.user.GoalID);
            MyGoalName_Lable.Text = db.goal.Name;
            MyGoalProgress_Label.Text = db.user.GoalProgress.ToString() + "%";
            int progress = db.user.GoalProgress/100;
            GoalProgress_ProgressBar.Progress = progress;
        }
    }
}