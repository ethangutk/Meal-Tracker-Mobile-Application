using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using SQLite;

namespace MealTracker
{
    public partial class MainPage : TabbedPage
    {
        public static RestService _restService;
        public static SQLiteConnection FoodEntryDBconn;
        public MainPage()
        {
            InitializeComponent();

            _restService = new RestService();

            string DBName = "FoodEntryDB.db";
            string libFolder = FileSystem.AppDataDirectory;
            string logDB = System.IO.Path.Combine(libFolder, DBName);

            FoodEntryDBconn = new SQLiteConnection(logDB);
            FoodEntryDBconn.CreateTable<FoodEntry>();
        }
    }
}
