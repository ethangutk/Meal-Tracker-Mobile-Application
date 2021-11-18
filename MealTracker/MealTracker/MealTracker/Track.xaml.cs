using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Track : ContentPage
    {
        public Track()
        {
            List<string> mealList = new List<string>()
            {
                "Breakfast", "Lunch", "Dinner", "Snacks"
            };
            InitializeComponent();
            PickerMeal.ItemsSource = mealList;
            PickerMeal.SelectedIndex = 0;
            NavigationPage.SetBackButtonTitle(this, "Back");
        }

        

        private void MacrosChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Entry b = (Entry)sender;
            b.TextColor = Color.Black;
            string filteredString = "";
            foreach (char c in b.Text.ToCharArray())
            {
                if ("1234567890".Contains(c)) filteredString += c;
            }
            b.Text = filteredString;
        }

        private async void searchItem(object sender, EventArgs e)
        {
            Search newSearchPage = new Search();
            await Navigation.PushAsync(newSearchPage);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            FoodEntry newEntry = new FoodEntry()
            {
                Name = EntryFoodName.Text,
                Calories = double.Parse(EntryCalories.Text),
                Carbs = double.Parse(EntryCarbs.Text),
                Protien = double.Parse(EntryProtien.Text),
                Fat = double.Parse(EntryFat.Text),
                Date = DatePickerForLog.Date,
                Meal = PickerMeal.SelectedItem.ToString()
            };
            MainPage.FoodEntryDBconn.Insert(newEntry);
        }
    }
}