using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealTracker
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodInfo : ContentPage
    {
        FoodEntry currentFood;

        string GenerateRequestUri(string id)
        {
            string requestUri = "https://api.spoonacular.com/food/menuItems/";
            requestUri += $"{id}";
            requestUri += $"?apiKey={"9ff1790882584ffabc27bb7fe715a133"}"; // Add api key here
            return requestUri;
        }

        private async void GenerateFacts(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {

                string uriRequest = GenerateRequestUri(id);
                FoodItemData foodItemResults = await MainPage._restService.GetFoodData(uriRequest);

                if (foodItemResults != null)
                {
                    LabelFoodName.Text = foodItemResults.Title;
                    foreach (Nutrient n in foodItemResults.Nutrition.Nutrients)
                    {
                        if (n.Macro.Equals("Calories"))
                        {
                            LabelFoodName.Text += " (" + n.Amount + " Calories)";
                            currentFood.Calories = n.Amount;
                        } else if (n.Macro.Equals("Fat"))
                        {
                            LabelFatDP.Text = n.PercentOfDailyNeeds + "%";
                            LabelFatAmount.Text = n.Amount + " " + n.Unit;
                            currentFood.Fat = n.Amount;
                        } else if (n.Macro.Equals("Carbohydrates"))
                        {
                            LabelCarbsDP.Text = n.PercentOfDailyNeeds + "%";
                            LabelCarbsAmount.Text = n.Amount + " " + n.Unit;
                            currentFood.Carbs = n.Amount;
                        } else if (n.Macro.Equals("Protein"))
                        {
                            LabelProtienDP.Text = n.PercentOfDailyNeeds + "%";
                            LabelProtienAmount.Text = n.Amount + " " + n.Unit;
                            currentFood.Protien = n.Amount;
                        }
                    }
                    addToLogButton.IsVisible = true;
                }
            }
        }

        public FoodInfo(int FoodId, string FoodImage, string FoodName, string FoodResturantName)
        {
            InitializeComponent();
            List<string> mealList = new List<string>()
            {
                "Breakfast", "Lunch", "Dinner", "Snacks"
            };
            ImageFood.Source = FoodImage;
            LabelFoodName.Text = FoodName + " (--- Calories)";
            LabelResturantName.Text = FoodResturantName;
            PickerMeal.ItemsSource = mealList;
            PickerMeal.SelectedIndex = 0;

            currentFood = new FoodEntry()
            {
                Name = FoodName + " (" + FoodResturantName + ")"
            };

            GenerateFacts(FoodId.ToString());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Add to database;
            var foodentryDBconn = MainPage.FoodEntryDBconn.Table<FoodEntry>();
            
            /*
             * currentFood object
             * Date
             * MealType
             * Name - Done
             * Fat - Done
             * Protien - Done
             * Carbs - Done
             * Calories - Done
             */
            currentFood.Meal = PickerMeal.SelectedItem.ToString();
            currentFood.Date = DatePickerCurrentFoodDate.Date;
            MainPage.FoodEntryDBconn.Insert(currentFood);
            Navigation.PopAsync();
        }
    }
}