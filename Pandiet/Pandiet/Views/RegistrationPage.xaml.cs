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
    public partial class RegistrationPage : ContentPage
    {
        DataBase _data = new DataBase();
        List<Gender> genders = new List<Gender>();
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new LoginAndRegistraionViewModel() { Navigation = this.Navigation };
            _data.GetAllGenders(genders);
            Gender_Picker.ItemsSource = genders;
        }

        private void Registration_Button_Clicked(object sender, EventArgs e)
        {
            if (Login_Entry.Text != null && Password_Entry.Text != null && Date_DatePicker.Date != null && Gender_Picker.SelectedItem != null && Weight_Entry.Text != null)
            {
                User user = new User();
                user.Login = Login_Entry.Text;
                user.Password = Password_Entry.Text;
                user.DateBirthday = Date_DatePicker.Date;
                user.GenderID = Gender_Picker.SelectedIndex + 1;
                user.Weight = Convert.ToDouble(Weight_Entry.Text);
                user.DietModeID = 1;
                user.NotificationsMode = 1;
                user.ProfileModeID = 1;
                user.GoalID = 1;
                user.GoalProgress = 0;
                user.CategoryPeopleID = 1;
                _data.DoesTheUserExist(Login_Entry.Text, Password_Entry.Text);
                if (_data.result == false)
                {
                    _data.UserAdd(user);
                    if (_data.result == true)
                    {
                        DisplayAlert("Уведомление", "Вы успешно зарегистрировали аккаунт!", "ОК");
                        Navigation.PopModalAsync();
                    }
                    else
                    {
                        DisplayAlert("Уведомление", "Что-то пошло не так, попробуйте позже!", "ОК");
                    }
                }
                else
                {
                    DisplayAlert("Уведомление", "Такой пользователь уже существует!", "ОК");
                }
            }
            else
            {
                DisplayAlert("Внимание!","Все поля должны быть заполнены!", "ОК");
            }
        }
    }
}