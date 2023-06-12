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
    public partial class CategoryFoodPage : ContentPage
    {
        DataBase db = new DataBase();
        CategoryFoodOnUser categoryFoodOnUser = new CategoryFoodOnUser();
        int _userID;
        public CategoryFoodPage(int userID)
        {
            InitializeComponent();
            _userID = userID;
            db.GetAllCategoryFoodOnUser(_userID);
            db.GetUser(_userID);
            if (db.user.CategoryPeopleID == 2)
            {
                MilkAndDairyProducts_StackLayout.IsVisible = false;
                Citrus_StackLayout.IsVisible = false;
                Nuts_StackLayout.IsVisible = false;
                FishAndCaviar_StackLayout.IsVisible = false;
                MollusksAndCrustaceans_StackLayout.IsVisible = false;
            }
            else if (db.user.CategoryPeopleID == 3)
            {
                Meat_StackLayout.IsVisible = false;
                MilkAndDairyProducts_StackLayout.IsVisible = false;
                Eggs_StackLayout.IsVisible = false;
                FishAndCaviar_StackLayout.IsVisible = false;
                MollusksAndCrustaceans_StackLayout.IsVisible = false;
            }
            for (int i = 0; i < db.categoryFoodOnUsers.Count; i++)
            {
                categoryFoodOnUser = db.categoryFoodOnUsers[i];
                switch (i)
                {
                    case 0: Cereals_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 1: Nuts_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 2: Legumes_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 3: Oilseeds_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 4: Fruits_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 5: Citrus_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 6: Berries_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 7: FruitVegetables_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 8: Roots_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 9: LeafyVegetables_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 10: FragrantGreens_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 11: Bulbous_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 12: Stem_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 13: HerbsAndSpices_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 14: Meat_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 15: MilkAndDairyProducts_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 16: Eggs_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 17: FishAndCaviar_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 18: MollusksAndCrustaceans_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 19: Mushrooms_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 20: Yeast_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 21: Seaweed_Switch.IsToggled = categoryFoodOnUser.Status; break;
                    case 22: Corn_Switch.IsToggled = categoryFoodOnUser.Status; break;
                }
            }
        }

        private void Cereals_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 1, Cereals_Switch.IsToggled);
        }

        private void Nuts_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 2, Nuts_Switch.IsToggled);
        }

        private void Legumes_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 3, Legumes_Switch.IsToggled);
        }

        private void Oilseeds_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 4, Oilseeds_Switch.IsToggled);
        }

        private void Fruits_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 5, Fruits_Switch.IsToggled);
        }

        private void Citrus_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 6, Citrus_Switch.IsToggled);
        }

        private void Berries_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 7, Berries_Switch.IsToggled);
        }

        private void FruitVegetables_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 8, FruitVegetables_Switch.IsToggled);
        }

        private void Roots_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 9, Roots_Switch.IsToggled);
        }

        private void LeafyVegetables_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 10, LeafyVegetables_Switch.IsToggled);
        }

        private void FragrantGreens_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 11, FragrantGreens_Switch.IsToggled);
        }

        private void Bulbous_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 12, Bulbous_Switch.IsToggled);
        }

        private void Stem_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 13, Stem_Switch.IsToggled);
        }

        private void HerbsAndSpices_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 14, HerbsAndSpices_Switch.IsToggled);
        }

        private void Meat_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 15, Meat_Switch.IsToggled);
        }

        private void MilkAndDairyProducts_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 16, MilkAndDairyProducts_Switch.IsToggled);
        }

        private void Eggs_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 17, Eggs_Switch.IsToggled);
        }

        private void FishAndCaviar_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 18, FishAndCaviar_Switch.IsToggled);
        }

        private void MollusksAndCrustaceans_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 19, MollusksAndCrustaceans_Switch.IsToggled);
        }

        private void Mushrooms_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 20, Mushrooms_Switch.IsToggled);
        }

        private void Yeast_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 21, Yeast_Switch.IsToggled);
        }

        private void Seaweed_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 22, Seaweed_Switch.IsToggled);
        }

        private void Corn_Switch_Toggled(object sender, ToggledEventArgs e)
        {
            db.CategoryFoodOnUserSwitchUpdate(_userID, 23, Corn_Switch.IsToggled);
        }
    }
}