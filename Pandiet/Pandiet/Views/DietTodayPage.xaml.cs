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
    public partial class DietTodayPage : ContentPage
    {
        int _dishID;
        DataBase db = new DataBase();
        List<int> dish = new List<int>();
        List<Dish> breakfastNice = new List<Dish>();
        List<Dish> lunchNice = new List<Dish>();
        List<Dish> dinnerNice = new List<Dish>();
        int _breakfastGenerate, _lunchGenerate, _dinnerGenerate;
        Random rand = new Random();
        string breakfastImageURI;
        string lunchImageURI;
        string dinnerImageURI;
        int trueCount = 0;
        int falseCount = 0;
        public DietTodayPage(int userID)
        {
            InitializeComponent();
            db.GetAllTrueCategoryFoodOnUser(userID);
            db.GetAllDishCategoryFood();
            db.GetAllDishes();
            //for (int i = 0; i < db.categoryFoodOnUsers.Count; i++)
            //{
            //    DisplayAlert("Status:" + db.categoryFoodOnUsers[i].Status, "CategoryFoodID:" + db.categoryFoodOnUsers[i].CategoryFoodID, "OK");
            //}
            for (int i = 0; i < db.dishCategoryFoods.Count; i++)
            {
                for (int j = 0; j < db.categoryFoodOnUsers.Count; j++)
                {
                    if (db.dishCategoryFoods[i].CategoryFoodID == db.categoryFoodOnUsers[j].CategoryFoodID && db.categoryFoodOnUsers[j].Status == true)
                    {
                        trueCount++;
                        //dish.Add(db.dishCategoryFoods[i].DishID);
                    }
                    else if (db.dishCategoryFoods[i].CategoryFoodID == db.categoryFoodOnUsers[j].CategoryFoodID && db.categoryFoodOnUsers[j].Status == false)
                    {
                        falseCount++;
                    }
                }
                if (i < db.dishCategoryFoods.Count - 1)
                {
                    if (db.dishCategoryFoods[i].DishID != db.dishCategoryFoods[i + 1].DishID)
                    {
                        if (trueCount > 0 && falseCount == 0)
                        {
                            dish.Add(db.dishCategoryFoods[i].DishID);
                            //DisplayAlert("DishID:" + db.dishCategoryFoods[i].DishID, "TrueCount" + trueCount, "Ф1");
                            //DisplayAlert("DishID:" + db.dishCategoryFoods[i].DishID, "FalseCount" + falseCount, "Ф1");
                            //DisplayAlert("DishID:" + db.dishCategoryFoods[i].DishID, "Был добавлен в список!", "Ф1");
                            trueCount = 0;
                            falseCount = 0;
                        }
                        else if (falseCount > 0)
                        {
                            trueCount = 0;
                            falseCount = 0;
                        }
                    }
                }
                else if (i == db.dishCategoryFoods.Count)
                {
                    if (db.dishCategoryFoods[i].DishID != db.dishCategoryFoods[i - 1].DishID)
                    {
                        if (trueCount > 0 && falseCount == 0)
                        {
                            dish.Add(db.dishCategoryFoods[i].DishID);
                            DisplayAlert("DishID:" + db.dishCategoryFoods[i].DishID, "TrueCount" + trueCount, "Ф2");
                            DisplayAlert("DishID:" + db.dishCategoryFoods[i].DishID, "FalseCount" + falseCount, "Ф2");
                            DisplayAlert("DishID:" + db.dishCategoryFoods[i].DishID, "Был добавлен в список!", "Ф2");
                            trueCount = 0;
                            falseCount = 0;
                        }
                        else if (falseCount > 0)
                        {
                            trueCount = 0;
                            falseCount = 0;
                        }
                    }
                }
            }

            //for (int i = 0; i < dish.Count; i++)
            //{
            //    for (int j = i + 1; j < dish.Count; j++)
            //    {
            //        if (dish[i] == dish[j])
            //        {
            //            dish.RemoveAt(j);
            //            j--;
            //        }
            //    }
            //}

            for (int i = 0; i < db.breakfast.Count; i++)
            {
                for (int j = 0; j < dish.Count; j++)
                {
                    if (db.breakfast[i].ID == dish[j])
                    {
                        breakfastNice.Add(new Dish()
                        {
                            ID = db.breakfast[i].ID,
                            Name = db.breakfast[i].Name,
                            Squirrels = db.breakfast[i].Squirrels,
                            Carbohydrates = db.breakfast[i].Carbohydrates,
                            Fats = db.breakfast[i].Fats,
                            Sugar = db.breakfast[i].Sugar,
                            Calories = db.breakfast[i].Calories,
                            Description = db.breakfast[i].Description,
                            Recipe = db.breakfast[i].Recipe,
                            TimesOfDayID = db.breakfast[i].TimesOfDayID
                        });
                    }
                }
            }

            for (int i = 0; i < db.lunch.Count; i++)
            {
                for (int j = 0; j < dish.Count; j++)
                {
                    if (db.lunch[i].ID == dish[j])
                    {
                        lunchNice.Add(new Dish()
                        {
                            ID = db.lunch[i].ID,
                            Name = db.lunch[i].Name,
                            Squirrels = db.lunch[i].Squirrels,
                            Carbohydrates = db.lunch[i].Carbohydrates,
                            Fats = db.lunch[i].Fats,
                            Sugar = db.lunch[i].Sugar,
                            Calories = db.lunch[i].Calories,
                            Description = db.lunch[i].Description,
                            Recipe = db.lunch[i].Recipe,
                            TimesOfDayID = db.lunch[i].TimesOfDayID
                        });
                    }
                }
            }

            for (int i = 0; i < db.dinner.Count; i++)
            {
                for (int j = 0; j < dish.Count; j++)
                {
                    if (db.dinner[i].ID == dish[j])
                    {
                        dinnerNice.Add(new Dish()
                        {
                            ID = db.dinner[i].ID,
                            Name = db.dinner[i].Name,
                            Squirrels = db.dinner[i].Squirrels,
                            Carbohydrates = db.dinner[i].Carbohydrates,
                            Fats = db.dinner[i].Fats,
                            Sugar = db.dinner[i].Sugar,
                            Calories = db.dinner[i].Calories,
                            Description = db.dinner[i].Description,
                            Recipe = db.dinner[i].Recipe,
                            TimesOfDayID = db.dinner[i].TimesOfDayID
                        });
                    }
                }
            }

            _breakfastGenerate = Convert.ToInt32(rand.Next(0, breakfastNice.Count));
            _lunchGenerate = Convert.ToInt32(rand.Next(0, lunchNice.Count));
            _dinnerGenerate = Convert.ToInt32(rand.Next(0, dinnerNice.Count));

            db.GetAllDishImages();

            for (int i = 0; i < db.images.Count; i++)
            {
                if (db.images[i].DishID == breakfastNice[_breakfastGenerate].ID)
                {
                    breakfastImageURI = db.images[i].Image;
                }
                else if (db.images[i].DishID == lunchNice[_lunchGenerate].ID)
                {
                    lunchImageURI = db.images[i].Image;
                }
                else if (db.images[i].DishID == dinnerNice[_dinnerGenerate].ID)
                {
                    dinnerImageURI = db.images[i].Image;
                }
            }

            BreakfastDishName_Label.Text = breakfastNice[_breakfastGenerate].Name;
            BreakfastDishCalories_Label.Text = "Каллории: " + breakfastNice[_breakfastGenerate].Calories.ToString() + " ккал.";
            BreakfastDishDescription_Label.Text = breakfastNice[_breakfastGenerate].Description;
            BreakfastDishImage_Image.Source = breakfastImageURI;

            LunchDishName_Label.Text = lunchNice[_lunchGenerate].Name;
            LunchDishCalories_Label.Text = "Каллории: " + lunchNice[_lunchGenerate].Calories.ToString() + " ккал.";
            LunchDishDescription_Label.Text = lunchNice[_lunchGenerate].Description;
            LunchDishImage_Image.Source = lunchImageURI;

            DinnerDishName_Label.Text = dinnerNice[_dinnerGenerate].Name;
            DinnerDishCalories_Label.Text = "Каллории: " + dinnerNice[_dinnerGenerate].Calories.ToString() + " ккал.";
            DinnerDishDescription_Label.Text = dinnerNice[_dinnerGenerate].Description;
            DinnerDishImage_Image.Source = dinnerImageURI;
        }

        private void DinnerDish_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RecipePage(dinnerNice[_dinnerGenerate].ID, dinnerImageURI));
        }

        private void LunchDish_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RecipePage(lunchNice[_lunchGenerate].ID, lunchImageURI));
        }

        private void BreakfastDish_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RecipePage(breakfastNice[_breakfastGenerate].ID, breakfastImageURI));
        }
    }
}