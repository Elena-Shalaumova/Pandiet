using Pandiet.Models;
using Pandiet.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Input;

namespace Pandiet.ViewModels
{
    public class LoginAndRegistraionViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ToRegistrationPageCommand { protected set; get; }
        public ICommand ToBackPageCommand { protected set; get; }
        public INavigation Navigation { get; set; }

        public LoginAndRegistraionViewModel()
        {
            ToRegistrationPageCommand = new Command(ToRegistrationPage);
            ToBackPageCommand = new Command(ToBackPage);
        }


        private void ToRegistrationPage()
        {
            Navigation.PushModalAsync(new RegistrationPage());
        }

        private void ToBackPage()
        {
            Navigation.PopModalAsync();
        }

    }
}
