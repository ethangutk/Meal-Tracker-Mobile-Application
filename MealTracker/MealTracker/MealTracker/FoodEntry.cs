using SQLite;
using System;

namespace MealTracker
{
    [Table("foodentry")]
    public class FoodEntry
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public DateTime Date { get; set;}
        public string Meal { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; } // Default unit is calories (cals.)
        public double Fat { get; set; } // Default unit is grams (g)
        public double Protien { get; set; } // Default unit is grams (g)
        public double Carbs { get; set; } // Default unit is grams (g)
    }

    public class LogsDatabaseCreation
    {
        public static void CreateDB(SQLiteConnection conn)
        {
            conn.CreateTable<FoodEntry>();
            // conn.DeleteAll<FoodEntry>();
        }
    }
}
