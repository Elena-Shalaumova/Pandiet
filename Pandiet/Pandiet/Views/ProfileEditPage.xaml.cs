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
    public partial class ProfileEditPage : ContentPage
    {
        DataBase _data = new DataBase();
        List<Gender> genders = new List<Gender>();
        int _userID;
        public ProfileEditPage(int userID)
        {
            InitializeComponent();
            _userID = userID;
            _data.GetAllGenders(genders);
            _data.GetUser(userID);
            Gender_Picker.ItemsSource = genders;
        }

        private void Accept_Button_Clicked(object sender, EventArgs e)
        {
            if (Date_DatePicker.Date != null && Weight_Entry.Text != "" && Gender_Picker.SelectedItem != null)
            {
                _data.UserUpdate(Date_DatePicker.Date, Convert.ToDouble(Weight_Entry.Text), Gender_Picker.SelectedIndex + 1, _userID);
                DisplayAlert("Уведомление!", "Изменение данных успешно завершено, пожалуйста, перезайдите в аккаунт для отображения новых данных!", "OK");
                Navigation.PopModalAsync();
            }
            else
            {
                DisplayAlert("Уведомление!", "Не оставляйте поля пустыми!", "OK");
            }
        }
    }
}