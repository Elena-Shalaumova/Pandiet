using Pandiet.Models;
using Pandiet.ViewModels;
using Pandiet.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pandiet
{
    public partial class MainPage : ContentPage
    {
        DataBase db = new DataBase();
        //List<User> users = new List<User>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginAndRegistraionViewModel() { Navigation = this.Navigation };
        }

        private void Login_Button_Clicked(object sender, EventArgs e)
        {
            if (Login_Entry.Text != null && Password_Entry.Text != null)
            {
                db.DoesTheUserExist(Login_Entry.Text, Password_Entry.Text);
                if (db.result == true)
                {
                    Login_Entry.Text = "";
                    Password_Entry.Text = "";
                    Navigation.PushModalAsync(new HubPage(db._actualUserID));
                    DisplayAlert("Уведомление!", "Вы успешно авторизировались!", "ОК");
                }
                else if (db.result == false)
                {
                    DisplayAlert("Уведомление!", "Неверный логин или пароль!", "ОК");
                }
            }
            else
            {
                DisplayAlert("Уведомление!", "Введите логин или пароль!", "ОК");
            }
        }
    }
}
