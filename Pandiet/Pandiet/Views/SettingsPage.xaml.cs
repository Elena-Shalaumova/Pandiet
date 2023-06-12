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
    public partial class SettingsPage : ContentPage
    {
        DataBase db = new DataBase();
        int _userID;
        public SettingsPage(int userID)
        {
            InitializeComponent();
            _userID = userID;
            db.GetUser(_userID);
            if (db.user.NotificationsMode == 1)
            {
                Notifications_Switch.IsToggled = true;
            }
            else if (db.user.NotificationsMode == 0)
            {
                Notifications_Switch.IsToggled = false;
            }
            switch (db.user.CategoryPeopleID)
            {
                case 1: Normal_RadioButton.IsChecked = true;
                    break;
                case 2: Allergic_RadioButton.IsChecked = true;
                    break;
                case 3: Vegetarian_RadioButton.IsChecked = true;
                    break;
            }
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (Normal_RadioButton.IsChecked == true)
            {
                db.CategoryPeopleUpdate(1, _userID);
            }
            else if (Allergic_RadioButton.IsChecked == true)
            {
                db.CategoryPeopleUpdate(2, _userID);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 16, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 6, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 2, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 18, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 19, false);
            }
            else if (Vegetarian_RadioButton.IsChecked == true)
            {
                db.CategoryPeopleUpdate(3, _userID);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 15, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 16, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 17, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 18, false);
                db.CategoryFoodOnUserSwitchUpdate(_userID, 19, false);
            }
        }

        private void Notifications_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            bool status = Notifications_Switch.IsToggled;
            db.NotificationsUpdate(status, _userID);
        }
    }
}