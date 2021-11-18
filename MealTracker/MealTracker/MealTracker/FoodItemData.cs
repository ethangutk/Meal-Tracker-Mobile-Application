using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * 
 * https://api.spoonacular.com/food/menuItems/424571
 * 
 * 
{
    "id": 424571,
    "title": "Bacon King Burger",
    "restaurantChain": "Burger King",
    "nutrition": {
        "nutrients": [
            {
                "name": "Fat",
                "amount": 69,
                "unit": "g",
                "percentOfDailyNeeds": 30
            },
            {
                "name": "Protein",
                "amount": 57,
                "unit": "g",
                "percentOfDailyNeeds": 35
            },
            {
                "name": "Calories",
                "amount": 1040,
                "unit": "cal",
                "percentOfDailyNeeds": 50
            },
            {
                "name": "Carbohydrates",
                "amount": 48,
                "unit": "g",
                "percentOfDailyNeeds": 35
            }
        ]
    }
}
 * 
 */


namespace MealTracker
{
    public class FoodItemData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("restaurantChain")]
        public string RestaurantChain { get; set; }

        [JsonProperty("nutrition")]
        public Nutrition Nutrition { get; set; }
    }

    public class Nutrition
    {
        [JsonProperty("nutrients")]
        public Nutrient[] Nutrients { get; set; }
    }

        public class Nutrient
    {
        [JsonProperty("name")]
        public string Macro { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("percentOfDailyNeeds")]
        public double PercentOfDailyNeeds { get; set; }
    }
}
