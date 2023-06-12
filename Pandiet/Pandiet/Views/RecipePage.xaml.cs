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
    public partial class RecipePage : ContentPage
    {
        DataBase db = new DataBase();
        public RecipePage(int dishID, string dishImageURI)
        {
            InitializeComponent();
            db.GetDish(dishID);
            DishImage_Image.Source = dishImageURI;
            DishName_Label.Text = db.recipeDish.Name;
            DishSquirrels_Label.Text = "Белки: " + db.recipeDish.Squirrels.ToString() + " г.";
            DishFats_Label.Text = "Жиры: " + db.recipeDish.Fats.ToString() + " г.";
            DishCarbohydrates_Label.Text = "Углеводы: " + db.recipeDish.Carbohydrates.ToString() + " г.";
            DishSugar_Label.Text = "Сахар: " + db.recipeDish.Sugar.ToString() + " г.";
            DishDescription_Label.Text = db.recipeDish.Description;
            DishRecipe_Label.Text = db.recipeDish.Recipe;

        }
    }
}