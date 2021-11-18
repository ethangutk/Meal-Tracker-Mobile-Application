using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/*
 * https://api.spoonacular.com/food/menuItems/search?query=burger&number=2
 * 
{
    "menuItems": [
        {
            "id": 419357,
            "title": "Burger Sliders",
            "restaurantChain": "Hooters",
            "image": "https://images.spoonacular.com/file/wximages/419357-312x231.png",
            "imageType": "png",
            "readableServingSize": null,
            "servingSize": null
        },
        {
            "id": 424571,
            "title": "Bacon King Burger",
            "restaurantChain": "Burger King",
            "image": "https://images.spoonacular.com/file/wximages/424571-312x231.png",
            "imageType": "png",
            "readableServingSize": null,
            "servingSize": null
        }
    ],
    "totalMenuItems": 6749,
    "type": "menuItem",
    "offset": 0,
    "number": 2,
}
*/


namespace MealTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        
        public Search()
        {
            InitializeComponent();

            List<ItemGeneralFacts> testList = new List<ItemGeneralFacts>();
            testList.Add(new ItemGeneralFacts()
                    {
                        Id = 424571,
                        Title = "Bacon King Burger",
                        ResturantChain = "Burger King",
                        Image = "https://images.spoonacular.com/file/wximages/424571-312x231.png"
            });
            SearchResultsList.ItemTemplate = CreateTemp();
            SearchResultsList.ItemsSource = testList;
        }

        DataTemplate CreateTemp()
        {
            DataTemplate r = new DataTemplate(() => {
                // WebClient client = new WebClient();
                // client.DownloadFile(new Uri("Image"));

                Image imageOfItem = new Image();
                imageOfItem.SetBinding(Image.SourceProperty, "Image");
                imageOfItem.HeightRequest = 80;
                imageOfItem.WidthRequest = 80;
                imageOfItem.Margin = new Thickness(10, 0, 0, 0);


                Label titleLabel = new Label();
                titleLabel.SetBinding(Label.TextProperty, "Title");
                titleLabel.FontSize = 20;
                titleLabel.TextColor = Color.Black;
                titleLabel.FontAttributes = FontAttributes.Bold;
                titleLabel.Margin = new Thickness(20, 0, 20, 0);

                Label resturantLabel = new Label();
                resturantLabel.SetBinding(Label.TextProperty, "ResturantChain");
                resturantLabel.FontSize = 16;
                resturantLabel.FontAttributes = FontAttributes.Italic;
                resturantLabel.TextColor = Color.DarkGray;
                resturantLabel.Margin = new Thickness(20, 0, 10, 0);

                StackLayout textsl = new StackLayout();
                textsl.Orientation = StackOrientation.Vertical;
                textsl.VerticalOptions = LayoutOptions.Center;
                textsl.Children.Add(titleLabel);
                textsl.Children.Add(resturantLabel);


                StackLayout sl = new StackLayout();
                sl.Orientation = StackOrientation.Horizontal;
                sl.VerticalOptions = LayoutOptions.Center;
                sl.Children.Add(imageOfItem);
                sl.Children.Add(textsl);
                return new ViewCell
                {
                    View = sl
                };
            });
            return r;
        }

        string GenerateRequestUri(string searchRequest)
        {
            string requestUri = "https://api.spoonacular.com/food/menuItems/search";
            requestUri += $"?query={EntrySearchBox.Text}";
            requestUri += $"&number={10}";
            requestUri += $"&apiKey={"9ff1790882584ffabc27bb7fe715a133"}"; // Add api key here
            return requestUri;
        }

        private async void SearchItems_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EntrySearchBox.Text))
            {
                
                string uriRequest = GenerateRequestUri(EntrySearchBox.Text);
                SearchPageData searchDataResults = await MainPage._restService.GetSearchData(uriRequest);
                // BindingContext = searchDataResults;

                if (searchDataResults != null)
                {
                    LabelNumberOfResults.Text = searchDataResults.TotalItemsFound + " results found, showing " + searchDataResults.NumberOfResults;
                    SearchResultsList.ItemTemplate = CreateTemp();
                    SearchResultsList.ItemsSource = searchDataResults.itemResults.ToList<ItemGeneralFacts>();
                } else
                {
                    LabelNumberOfResults.Text = "no results found";
                }
                
            }
        }

        private async void SearchResultsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView list = (ListView)sender;
            if (SearchResultsList.SelectedItem != null)
            {
                ItemGeneralFacts selectedItem = (ItemGeneralFacts)list.SelectedItem;
                FoodInfo newFoodInfo = new FoodInfo(selectedItem.Id, selectedItem.Image, selectedItem.Title, selectedItem.ResturantChain);
                await Navigation.PushAsync(newFoodInfo);
                SearchResultsList.SelectedItem = null;
            }
            
        }
    }
}