using Pandiet.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pandiet.ViewModels
{
    public class GoalsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand ToGoalsPageCommand { protected set; get; }
        int _userID;
        public GoalsViewModel(int userID)
        {
            _userID = userID;
            ToGoalsPageCommand = new Command(ToGoalsPage);
        }

        private void ToGoalsPage()
        {
            Navigation.PushModalAsync(new GoalsPage(_userID));
        }
    }
}
