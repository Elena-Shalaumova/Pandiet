using Pandiet.Views;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pandiet.ViewModels
{
    public class HubViewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ToProfilePageCommand { protected set; get; }
        public ICommand ToSettinsPageCommand { protected set; get; }
        public ICommand ToMyGoalPageCommand { protected set; get; }
        public ICommand ToUpdateDiscriptionPageCommand { protected set; get; }
        public ICommand ToDietTodayPageCommand { protected set; get; }
        public ICommand ToCategoryFoodPageCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        public int _userID;

        public HubViewModel(int userID)
        {
            _userID = userID;
            ToProfilePageCommand = new Command(ToProfilePage);
            ToSettinsPageCommand = new Command(ToSettingsPage);
            ToMyGoalPageCommand = new Command(ToMyGoalPage);
            ToUpdateDiscriptionPageCommand = new Command(ToUpdateDisriptionPage);
            ToDietTodayPageCommand = new Command(ToDietTodayPage);
            ToCategoryFoodPageCommand = new Command(ToCategoryFoodPage);
        }

        private void ToCategoryFoodPage()
        {
            Navigation.PushModalAsync(new CategoryFoodPage(_userID));
        }

        private void ToProfilePage()
        {
            Navigation.PushModalAsync(new ProfilePage(_userID));
        }

        private void ToSettingsPage()
        {
            Navigation.PushModalAsync(new SettingsPage(_userID));
        }

        private void ToMyGoalPage()
        {
            Navigation.PushModalAsync(new MyGoalPage(_userID));
        }
        
        private void ToUpdateDisriptionPage()
        {
            Navigation.PushModalAsync(new UpdateDiscriptionPage());
        }

        private void ToDietTodayPage()
        {
            Navigation.PushModalAsync(new DietTodayPage(_userID));
        }
    }
}
