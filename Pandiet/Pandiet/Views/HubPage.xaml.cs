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
    public partial class HubPage : ContentPage
    {
        DataBase data = new DataBase();
        List<CategoryFoodOnUser> categoryFoodOnUsers = new List<CategoryFoodOnUser>();
        public HubPage(int userID)
        {
            InitializeComponent();
            BindingContext = new HubViewModel(userID) { Navigation = this.Navigation };
            data.GetAllCategoryFoodOnUser(userID);
            if (data.result == false)
            {
                for (int i = 1; i <= 22; i++)
                {
                    categoryFoodOnUsers.Add(new CategoryFoodOnUser()
                    {
                        UserID = userID,
                        CategoryFoodID = i,
                        Status = false
                    });
                }
                data.UserCategoriesFoodAddFirst(categoryFoodOnUsers);
            }
            data.GetUser(userID);
            UserName_Label.Text = data.user.Login;
            if (data.user.ProfileModeID == 1)
            {
                UserProfileMode_Label.Text = "Стандарт";
            }
            else if (data.user.ProfileModeID == 2)
            {
                UserProfileMode_Label.Text = "Премиум";
            }
            UserGoalProgress_Label.Text = data.user.GoalProgress.ToString() + "%";
        }
    }
}