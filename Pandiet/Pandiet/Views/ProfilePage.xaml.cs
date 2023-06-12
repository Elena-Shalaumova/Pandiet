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
    public partial class ProfilePage : ContentPage
    {
        DataBase db = new DataBase();
        int _userID;
        public ProfilePage(int userID)
        {
            InitializeComponent();
            _userID = userID;
            db.GetUser(userID);
            UserID_Label.Text = "ID: " + userID;
            UserName_Label.Text = db.user.Login;
            if (db.user.ProfileModeID == 1)
            {
                ProfileMode_Label.Text = "Стандартный профиль";
            }
            else if (db.user.ProfileModeID == 2)
            {
                ProfileMode_Label.Text = "Премиум профиль";
            }
            DateTime dateBirthday = db.user.DateBirthday;
            DateBirthday_Label.Text = "Дата рождения: " + dateBirthday.Year.ToString() + "." + dateBirthday.Month.ToString() + "." + dateBirthday.Day.ToString();
            Weight_Label.Text = "Вес: " + db.user.Weight.ToString();
            if (db.user.GenderID == 1)
            {
                Gender_Label.Text = "Пол: Мужской";
            }
            else if (db.user.GenderID == 2)
            {
                Gender_Label.Text = "Пол: Женский";
            }
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new IMTPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProfileEditPage(_userID));
        }
    }
}