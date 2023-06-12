using Pandiet.Models;
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
    public partial class GoalsPage : ContentPage
    {
        DataBase db = new DataBase();
        Goal goal = new Goal();
        int _userID;
        public GoalsPage(int userID)
        {
            _userID = userID;
            InitializeComponent();
            db.GetAllGoals();
            MyListView.ItemsSource = db.goals;
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            goal = (Goal)e.Item;
            db.UserGoalIDUpdate(goal.ID,_userID);
            DisplayAlert("Уведомление!", "Вы успешно сменили цель, пожалуйста, перезайдите в аккаунт для отображения новых данных!", "ОК");
            Navigation.PopModalAsync();
        }
    }
}