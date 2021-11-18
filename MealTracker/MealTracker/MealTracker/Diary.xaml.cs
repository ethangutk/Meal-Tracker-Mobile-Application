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
    public partial class Diary : ContentPage
    {
        public static DateTime currentDateTime;
        public Diary()
        {
            InitializeComponent();
            DataTemplate listTemp = CreateTemp();
            currentDateTime = diaryDatePicker.Date;
            ListViewBreakfast.ItemTemplate = listTemp;
            ListViewLunch.ItemTemplate = listTemp;
            ListViewDinner.ItemTemplate = listTemp;
            ListViewSnacks.ItemTemplate = listTemp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateDiary();
        }

        public void UpdateDiary()
        {
            if (MainPage.FoodEntryDBconn != null)
            {
                List<FoodEntry> dbList = MainPage.FoodEntryDBconn.Table<FoodEntry>().ToList();
                List<FoodEntry> breakfast = new List<FoodEntry>();
                List<FoodEntry> lunch = new List<FoodEntry>();
                List<FoodEntry> dinner = new List<FoodEntry>();
                List<FoodEntry> snacks = new List<FoodEntry>();


                foreach (FoodEntry foodentry in dbList)
                {
                    // If date does not equal, continue to the top of the loop
                    if (!diaryDatePicker.Date.Equals(foodentry.Date)) continue;

                    if (foodentry.Meal.Equals("Breakfast")) breakfast.Add(foodentry);
                    else if (foodentry.Meal.Equals("Lunch")) lunch.Add(foodentry);
                    else if (foodentry.Meal.Equals("Dinner")) dinner.Add(foodentry);
                    else if (foodentry.Meal.Equals("Snacks")) snacks.Add(foodentry);
                }
                ListViewBreakfast.ItemsSource = breakfast;
                ListViewLunch.ItemsSource = lunch;
                ListViewDinner.ItemsSource = dinner;
                ListViewSnacks.ItemsSource = snacks;
            }
        }

        DataTemplate CreateTemp()
        {
            DataTemplate r = new DataTemplate(() => {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                nameLabel.FontSize = 12;
                nameLabel.FontAttributes = FontAttributes.Bold;
                nameLabel.TextColor = Color.Black;
                nameLabel.Margin = new Thickness(10, 5, 10, 5);
                Grid.SetRow(nameLabel, 0);
                Grid.SetColumn(nameLabel, 0);

                Label caloriesLabel = new Label();
                caloriesLabel.SetBinding(Label.TextProperty, "Calories");
                caloriesLabel.FontSize = 12;
                caloriesLabel.FontAttributes = FontAttributes.Bold;
                caloriesLabel.TextColor = Color.Black;
                Grid.SetRow(caloriesLabel, 0);
                Grid.SetColumn(caloriesLabel, 1);

                Label carbsLabel = new Label();
                carbsLabel.SetBinding(Label.TextProperty, "Carbs");
                carbsLabel.FontSize = 12;
                carbsLabel.FontAttributes = FontAttributes.Bold;
                carbsLabel.TextColor = Color.Navy;
                Grid.SetRow(carbsLabel, 0);
                Grid.SetColumn(carbsLabel, 2);

                Label fatLabel = new Label();
                fatLabel.SetBinding(Label.TextProperty, "Fat");
                fatLabel.FontSize = 12;
                fatLabel.FontAttributes = FontAttributes.Bold;
                fatLabel.TextColor = Color.Maroon;
                Grid.SetRow(fatLabel, 0);
                Grid.SetColumn(fatLabel, 3);

                Label protienLabel = new Label();
                protienLabel.SetBinding(Label.TextProperty, "Protien");
                protienLabel.FontSize = 12;
                protienLabel.FontAttributes = FontAttributes.Bold;
                protienLabel.TextColor = Color.DarkGreen;
                Grid.SetRow(protienLabel, 0);
                Grid.SetColumn(protienLabel, 4);

                // Create grid for list element 5x1
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                grid.ColumnDefinitions[0].Width = new GridLength(200, GridUnitType.Absolute);
                grid.RowDefinitions.Add(new RowDefinition());

                grid.Children.Add(nameLabel);
                grid.Children.Add(caloriesLabel);
                grid.Children.Add(fatLabel);
                grid.Children.Add(carbsLabel);
                grid.Children.Add(protienLabel);

                // Set the grid as the view
                return new ViewCell
                {
                    View = grid
                };
            });
            return r;
        }

        private void diaryDatePicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            currentDateTime = diaryDatePicker.Date;
            UpdateDiary();
        }
    }
}