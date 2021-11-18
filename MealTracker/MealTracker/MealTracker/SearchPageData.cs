using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealTracker
{
    /*
     * After meals are searched up, the user will be able to click
     * an item and get the facts about that item.
     * 
    QUERY:   https://api.spoonacular.com/food/menuItems/search?query=burger&number=2

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
    public class SearchPageData
    {
        [JsonProperty("menuItems")]
        public ItemGeneralFacts[] itemResults { get; set; }

        [JsonProperty("totalMenuItems")]
        public int TotalItemsFound { get; set; }

        [JsonProperty("number")]
        public int NumberOfResults { get; set; }
    }

    public class ItemGeneralFacts
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("restaurantChain")]
        public string ResturantChain { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}
