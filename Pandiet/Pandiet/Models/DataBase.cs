using System;
using Pandiet.Views;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Drawing;
using Xamarin.Forms;

namespace Pandiet.Models
{
    internal class DataBase
    {
        string srvrdbname = "db_Pandiet";
        string srvrname = "192.168.1.8";
        string srvrusername = "PandietAdmin";
        string srvrpassword = "1234567890";
        public SqlConnection sqlConnection;
        public int _actualUserID;
        public User user = new User();
        public Dish dish = new Dish();
        public Dish breakfastOne = new Dish();
        public Dish lunchOne = new Dish();
        public Dish dinnerOne = new Dish();
        public Dish recipeDish = new Dish();
        public Goal goal = new Goal();
        public bool result = false;
        public List<User> users = new List<User>();
        public List<Goal> goals = new List<Goal>(); 
        public List<ImageDB> images = new List<ImageDB>();
        public List<CategoryFoodOnUser> categoryFoodOnUsers = new List<CategoryFoodOnUser>();
        public List<CategoryFood> categoryFoods = new List<CategoryFood>();
        public List<Dish> breakfast = new List<Dish>();
        public List<Dish> lunch = new List<Dish>();
        public List<Dish> dinner = new List<Dish>();
        public List<DishCategoryFood> dishCategoryFoods = new List<DishCategoryFood>();
        public DataBase()
        {
            string sqlconn = $"Data Source={srvrname};Initial Catalog={srvrdbname};User Id={srvrusername};Password={srvrpassword}";
            sqlConnection = new SqlConnection(sqlconn);
        }

        public void GetAllUsers(List<User> _users)
        {
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.User_Table";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _users.Add(new User()
                    {
                        ID = Convert.ToInt32(reader["User_ID"]),
                        Login = reader["User_Login"].ToString(),
                        Password = reader["User_Password"].ToString(),
                        DateBirthday = Convert.ToDateTime(reader["User_Birthday"]),
                        GenderID = Convert.ToInt32(reader["User_GenderID"]),
                        Weight = Convert.ToDouble(reader["User_Weight"]),
                        DietModeID = Convert.ToInt32(reader["User_DietModeID"]),
                        NotificationsMode = Convert.ToInt32(reader["User_NotificationsMode"]),
                        ProfileModeID = Convert.ToInt32(reader["User_ProfileModeID"]),
                        GoalID = Convert.ToInt32(reader["User_GoalID"]),
                        GoalProgress = Convert.ToInt32(reader["User_GoalProgress"]),
                        CategoryPeopleID = Convert.ToInt32(reader["User_CategoryPeopleID"])
                    });
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllGoals()
        {
            GetAllGoalImages();
            sqlConnection.Open();
            string queryString = "Select * from dbo.Goal_Table";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    goals.Add(new Goal()
                    {
                        ID = Convert.ToInt32(reader["Goal_ID"]),
                        Name = reader["Goal_Name"].ToString(),
                        GoalMode = Convert.ToInt32(reader["Goal_Mode"]),
                        Duration = Convert.ToDouble(reader["Goal_Duration"]),
                        Description = reader["Goal_Description"].ToString()
                    });
                }
            }
            for (int i = 0; i < goals.Count; i++)
            {
                for (int j = 0; j < images.Count; j++)
                {
                    if (goals[i].ID == images[j].GoalID)
                    {
                        goals[i].Image = images[j].Image;
                    }
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllCategoryFood()
        {
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.CategoryFood_Table";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categoryFoods.Add(new CategoryFood()
                    {
                        ID = Convert.ToInt32(reader["CategoryFood_ID"]),
                        Name = reader["CategoryFood_Name"].ToString()
                    });
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllDishes()
        {
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.Dish_Table WHERE Dish_TimesOfDayID=1";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    breakfast.Add(new Dish()
                    {
                        ID = Convert.ToInt32(reader["Dish_ID"]),
                        Name = reader["Dish_Name"].ToString(),
                        Squirrels = Convert.ToInt32(reader["Dish_Squirrels"]),
                        Carbohydrates = Convert.ToInt32(reader["Dish_Carbohydrates"]),
                        Fats = Convert.ToInt32(reader["Dish_Fats"]),
                        Calories = Convert.ToInt32(reader["Dish_Calories"]),
                        Sugar = Convert.ToInt32(reader["Dish_Sugar"]),
                        Description = reader["Dish_Description"].ToString(),
                        Recipe = reader["Dish_Recipe"].ToString(),
                        TimesOfDayID = Convert.ToInt32(reader["Dish_TimesOfDayID"])
                    });
                }
            }
            reader.Close();
            queryString = "SELECT * FROM dbo.Dish_Table WHERE Dish_TimesOfDayID=2";
            command = new SqlCommand(queryString, sqlConnection);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    lunch.Add(new Dish()
                    {
                        ID = Convert.ToInt32(reader["Dish_ID"]),
                        Name = reader["Dish_Name"].ToString(),
                        Squirrels = Convert.ToInt32(reader["Dish_Squirrels"]),
                        Carbohydrates = Convert.ToInt32(reader["Dish_Carbohydrates"]),
                        Fats = Convert.ToInt32(reader["Dish_Fats"]),
                        Calories = Convert.ToInt32(reader["Dish_Calories"]),
                        Sugar = Convert.ToInt32(reader["Dish_Sugar"]),
                        Description = reader["Dish_Description"].ToString(),
                        Recipe = reader["Dish_Recipe"].ToString(),
                        TimesOfDayID = Convert.ToInt32(reader["Dish_TimesOfDayID"])
                    });
                }
            }
            reader.Close();
            queryString = "SELECT * FROM dbo.Dish_Table WHERE Dish_TimesOfDayID=3";
            command = new SqlCommand(queryString, sqlConnection);
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dinner.Add(new Dish()
                    {
                        ID = Convert.ToInt32(reader["Dish_ID"]),
                        Name = reader["Dish_Name"].ToString(),
                        Squirrels = Convert.ToInt32(reader["Dish_Squirrels"]),
                        Carbohydrates = Convert.ToInt32(reader["Dish_Carbohydrates"]),
                        Fats = Convert.ToInt32(reader["Dish_Fats"]),
                        Calories = Convert.ToInt32(reader["Dish_Calories"]),
                        Sugar = Convert.ToInt32(reader["Dish_Sugar"]),
                        Description = reader["Dish_Description"].ToString(),
                        Recipe = reader["Dish_Recipe"].ToString(),
                        TimesOfDayID = Convert.ToInt32(reader["Dish_TimesOfDayID"])
                    });
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllCategoryFoodOnUser(int userID)
        {
            sqlConnection.Open();
            string queryString = $"SELECT * FROM dbo.CategoryFoodOnUser_Table WHERE CategoryFoodOnUser_UserID='{userID}'";
            SqlCommand command = new SqlCommand(queryString,sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categoryFoodOnUsers.Add(new CategoryFoodOnUser()
                    {
                        ID = Convert.ToInt32(reader["CategoryFoodOnUser_UserID"]),
                        UserID = Convert.ToInt32(reader["CategoryFoodOnUser_UserID"]),
                        CategoryFoodID = Convert.ToInt32(reader["CategoryFoodOnUser_CategoryFoodID"]),
                        Status = (bool)reader["CategoryFoodOnUser_Status"]
                    });
                }
                result = true;
            }
            else
            {
                result = false;
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetDish(int dishID)
        {
            sqlConnection.Open();
            string queryString = $"SELECT * FROM dbo.Dish_Table WHERE Dish_ID='{dishID}'";
            SqlCommand command = new SqlCommand(queryString,sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                recipeDish.ID = Convert.ToInt32(reader["Dish_ID"]);
                recipeDish.Name = reader["Dish_Name"].ToString();
                recipeDish.Squirrels = Convert.ToInt32(reader["Dish_Squirrels"]);
                recipeDish.Carbohydrates = Convert.ToInt32(reader["Dish_Carbohydrates"]);
                recipeDish.Fats = Convert.ToInt32(reader["Dish_Fats"]);
                recipeDish.Calories = Convert.ToInt32(reader["Dish_Calories"]);
                recipeDish.Sugar = Convert.ToInt32(reader["Dish_Sugar"]);
                recipeDish.Description = reader["Dish_Description"].ToString();
                recipeDish.Recipe = reader["Dish_Recipe"].ToString();
                recipeDish.TimesOfDayID = Convert.ToInt32(reader["Dish_TimesOfDayID"]);
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllTrueCategoryFoodOnUser(int userID)
        {
            sqlConnection.Open();
            string queryString = $"SELECT * FROM dbo.CategoryFoodOnUser_Table WHERE CategoryFoodOnUser_UserID='{userID}'";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categoryFoodOnUsers.Add(new CategoryFoodOnUser()
                    {
                        ID = Convert.ToInt32(reader["CategoryFoodOnUser_UserID"]),
                        UserID = Convert.ToInt32(reader["CategoryFoodOnUser_UserID"]),
                        CategoryFoodID = Convert.ToInt32(reader["CategoryFoodOnUser_CategoryFoodID"]),
                        Status = (bool)reader["CategoryFoodOnUser_Status"]
                    });
                }
                result = true;
            }
            else
            {
                result = false;
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllDishCategoryFood()
        {
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.DishCategoryFood_Table";
            SqlCommand command = new SqlCommand(queryString,sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dishCategoryFoods.Add(new DishCategoryFood()
                    {
                        ID = Convert.ToInt32(reader["DishCategoryFood_ID"]),
                        DishID = Convert.ToInt32(reader["DishCategoryFood_DishID"]),
                        CategoryFoodID = Convert.ToInt32(reader["DishCategoryFood_CategoryFoodID"])
                    });
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllGoalImages()
        {
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.Image_Table WHERE Image_GoalID IS NOT NULL";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    images.Add(new ImageDB()
                    {
                        ID = Convert.ToInt32(reader["Image_ID"]),
                        GoalID = Convert.ToInt32(reader["Image_GoalID"]),
                        Image = reader["Image"].ToString()
                    });
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetAllDishImages()
        {
            sqlConnection.Open();
            string queryString = "SELECT * FROM dbo.Image_Table WHERE Image_DishID IS NOT NULL";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    images.Add(new ImageDB()
                    {
                        ID = Convert.ToInt32(reader["Image_ID"]),
                        DishID = Convert.ToInt32(reader["Image_DishID"]),
                        Image = reader["Image"].ToString()
                    });
                }
            }
            reader.Close();
            sqlConnection.Close();
        }

        public void GetUserGoal(int userGoalID)
        {
            this.result = false;
            sqlConnection.Open();
            string queryString = "Select * from dbo.Goal_Table";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    goals.Add(new Goal()
                    {
                        ID = Convert.ToInt32(reader["Goal_ID"]),
                        Name = reader["Goal_Name"].ToString(),
                        GoalMode = Convert.ToInt32(reader["Goal_Mode"]),
                        Duration = Convert.ToDouble(reader["Goal_Duration"]),
                        Description = reader["Goal_Description"].ToString()
                    });
                }
                for (int i = 0; i < goals.Count; i++)
                {
                    if (userGoalID == goals[i].ID)
                    {
                        this.goal = goals[i];
                        this.result = true;
                        break;
                    }
                    else
                    {
                        this.result = false;
                    }
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        public void NotificationsUpdate(bool status, int userID)
        {
            sqlConnection.Open();
            int NotificationsMode;
            if (status == true)
            {
                NotificationsMode = 1;
                string qerystr = $"UPDATE dbo.User_Table SET User_NotificationsMode='{NotificationsMode}' WHERE User_ID='{userID}'";

                using (SqlCommand command = new SqlCommand(qerystr, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            else if (status == false)
            {
                NotificationsMode = 0;
                string qerystr = $"UPDATE dbo.User_Table SET User_NotificationsMode='{NotificationsMode}' WHERE User_ID='{userID}'";

                using (SqlCommand command = new SqlCommand(qerystr, sqlConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            sqlConnection.Close();
        }

        public void CategoryPeopleUpdate(int categoryID, int userID)
        {
            sqlConnection.Open();

            string qerystr = $"UPDATE dbo.User_Table SET User_CategoryPeopleID='{categoryID}' WHERE User_ID='{userID}'";

            using (SqlCommand command = new SqlCommand(qerystr, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }

        public void UserUpdate(DateTime birthday, double weight, int genderID, int userID)
        {
            sqlConnection.Open();

            string qerystr = $"UPDATE dbo.User_Table SET User_Birthday='{birthday}', User_Weight='{weight}', User_GenderID='{genderID}' WHERE User_ID='{userID}'";

            using (SqlCommand command = new SqlCommand(qerystr, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }

        public void CategoryFoodOnUserSwitchUpdate(int userID, int categoryFoodID, bool status)
        {
            sqlConnection.Open();

            string qerystr = $"UPDATE dbo.CategoryFoodOnUser_Table SET CategoryFoodOnUser_Status='{status}' WHERE CategoryFoodOnUser_UserID='{userID}' AND CategoryFoodOnUser_CategoryFoodID='{categoryFoodID}'";

            using (SqlCommand command = new SqlCommand(qerystr, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }

        public void UserGoalIDUpdate(int goalID, int userID)
        {
            sqlConnection.Open();
            int newprogress = 0;
            string qerystr = $"UPDATE dbo.User_Table SET User_GoalID='{goalID}', User_GoalProgress='{newprogress}' WHERE User_ID='{userID}'";

            using (SqlCommand command = new SqlCommand(qerystr, sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }

        public void DoesTheUserExist(string _login, string _password)
        {
            this.result = false;
            sqlConnection.Open();
            string queryString = "Select * from dbo.User_Table";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        ID = Convert.ToInt32(reader["User_ID"]),
                        Login = reader["User_Login"].ToString(),
                        Password = reader["User_Password"].ToString(),
                        DateBirthday = Convert.ToDateTime(reader["User_Birthday"]),
                        GenderID = Convert.ToInt32(reader["User_GenderID"]),
                        Weight = Convert.ToDouble(reader["User_Weight"]),
                        DietModeID = Convert.ToInt32(reader["User_DietModeID"]),
                        NotificationsMode = Convert.ToInt32(reader["User_NotificationsMode"]),
                        ProfileModeID = Convert.ToInt32(reader["User_ProfileModeID"]),
                        GoalID = Convert.ToInt32(reader["User_GoalID"]),
                        GoalProgress = Convert.ToInt32(reader["User_GoalProgress"]),
                        CategoryPeopleID = Convert.ToInt32(reader["User_CategoryPeopleID"])
                    });
                }
                for (int i = 0; i < users.Count; i++)
                {
                    if (_login == users[i].Login && _password == users[i].Password)
                    {
                        this._actualUserID = users[i].ID;
                        this.result = true;
                        break;
                    }
                    else
                    {
                        this.result = false;
                    }
                }
            }
            
            reader.Close();
            sqlConnection.Close();
        }

        public void GetUser(int _id)
        {
            this.result = false;
            sqlConnection.Open();
            string queryString = "Select * from dbo.User_Table";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        ID = Convert.ToInt32(reader["User_ID"]),
                        Login = reader["User_Login"].ToString(),
                        Password = reader["User_Password"].ToString(),
                        DateBirthday = Convert.ToDateTime(reader["User_Birthday"]),
                        GenderID = Convert.ToInt32(reader["User_GenderID"]),
                        Weight = Convert.ToDouble(reader["User_Weight"]),
                        DietModeID = Convert.ToInt32(reader["User_DietModeID"]),
                        NotificationsMode = Convert.ToInt32(reader["User_NotificationsMode"]),
                        ProfileModeID = Convert.ToInt32(reader["User_ProfileModeID"]),
                        GoalID = Convert.ToInt32(reader["User_GoalID"]),
                        GoalProgress = Convert.ToInt32(reader["User_GoalProgress"]),
                        CategoryPeopleID = Convert.ToInt32(reader["User_CategoryPeopleID"])
                    });
                }
                for (int i = 0; i < users.Count; i++)
                {
                    if (_id == users[i].ID)
                    {
                        this.user = users[i];
                        this.result = true;
                        break;
                    }
                    else
                    {
                        this.result = false;
                    }
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

        public void UserAdd(User user)
        {
            this.result = false;
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand("INSERT INTO User_Table VALUES (@User_Login, @User_Password, @User_Birthday, @User_GenderID, @User_Weight, @User_DietModeID, @User_NotificationsMode, @User_ProfileModeID, @User_GoalID, @User_GoalProgress, @User_CategoryPeopleID)", sqlConnection))
            {
                command.Parameters.Add(new SqlParameter("User_Login", user.Login));
                command.Parameters.Add(new SqlParameter("User_Password", user.Password));
                command.Parameters.Add(new SqlParameter("User_Birthday", user.DateBirthday));
                command.Parameters.Add(new SqlParameter("User_GenderID", user.GenderID));
                command.Parameters.Add(new SqlParameter("User_Weight", user.Weight));
                command.Parameters.Add(new SqlParameter("User_DietModeID", user.DietModeID));
                command.Parameters.Add(new SqlParameter("User_NotificationsMode", user.NotificationsMode));
                command.Parameters.Add(new SqlParameter("User_ProfileModeID", user.ProfileModeID));
                command.Parameters.Add(new SqlParameter("User_GoalID", user.GoalID));
                command.Parameters.Add(new SqlParameter("User_GoalProgress", user.GoalProgress));
                command.Parameters.Add(new SqlParameter("User_CategoryPeopleID", user.CategoryPeopleID));
                
                command.ExecuteNonQuery();
            }
            sqlConnection.Close();
            this.result = true;
        }

        public void UserCategoriesFoodAddFirst(List<CategoryFoodOnUser> list)
        {
            sqlConnection.Open();
            for (int i = 0; i < list.Count; i++)
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.CategoryFoodOnUser_Table VALUES (@CategoryFoodOnUser_UserID, @CategoryFoodOnUser_CategoryFoodID, @CategoryFoodOnUser_Status)", sqlConnection))
                {
                    cmd.Parameters.Add(new SqlParameter("CategoryFoodOnUser_UserID", list[i].UserID));
                    cmd.Parameters.Add(new SqlParameter("CategoryFoodOnUser_CategoryFoodID", list[i].CategoryFoodID));
                    cmd.Parameters.Add(new SqlParameter("CategoryFoodOnUser_Status", list[i].Status));
                    cmd.ExecuteNonQuery();
                }
            }
            sqlConnection.Close();
        }

        public void GetAllGenders(List<Gender> _genders)
        {
            sqlConnection.Open();
            string queryString = "SELECT * FROM Gender_Table";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    _genders.Add(new Gender()
                    {
                        Name = reader["Gender_Name"].ToString()
                    });
                }
            }

            reader.Close();
            sqlConnection.Close();
        }

    }
}
