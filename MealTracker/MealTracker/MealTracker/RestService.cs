using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MealTracker
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<SearchPageData> GetSearchData(string query)
        {
            SearchPageData searchPageData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    searchPageData = JsonConvert.DeserializeObject<SearchPageData>(content);
                    JObject d = JObject.Parse(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return searchPageData;
        }

        public async Task<FoodItemData> GetFoodData(string query)
        {
            FoodItemData foodPageData = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    foodPageData = JsonConvert.DeserializeObject<FoodItemData>(content);
                    JObject d = JObject.Parse(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return foodPageData;
        }
    }
}
