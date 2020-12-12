using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Library

{
    // POCO for a Menu Item
    public class MenuItem
    {
        public int MealNumber { get; set; } // will serve as UNIQUE ID number
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> MealIngredients { get; set; } = new List<string>();
        public double MealPrice { get; set; }

        public MenuItem() { } // overload constructor
        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> mealIngredients, double mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }


    }
}
