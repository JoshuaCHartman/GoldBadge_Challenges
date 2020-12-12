using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Library

{
    public class MenuItemRepo
    {
        
        // 1 -FIELD for use in CRUD and to access CRUD functions 
        private List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        //CRUD
        //Create - add MenuItem to the list
        public void AddMenuItemToList(MenuItem menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }

        //Read - return the List of MenuItems
        public List<MenuItem> GetMenuItemList()
        {
            return _listOfMenuItems;
        }

        //Update - update properties of a MenuItem by MEAL NUMBER using Get helper method
        public bool UpdateMenuItem(MenuItem oldMenuItem, MenuItem newMenuItem)
        {

            // Update the MenuItem
            if (oldMenuItem != null)
            {
                oldMenuItem.MealNumber = newMenuItem.MealNumber;
                oldMenuItem.MealName = newMenuItem.MealName;
                oldMenuItem.MealDescription = newMenuItem.MealDescription;
                oldMenuItem.MealIngredients = newMenuItem.MealIngredients;
                oldMenuItem.MealPrice = newMenuItem.MealPrice;

                return true;
            }
            else
            {
                return false;
            }

        }

        //Delete - remove MenuItem by Meal Number using Get helper method
        public bool DeleteMenuItemByMealNumber(int originalMenuNumber)
        {
            // Get the MenuItem by Mealnumber
            MenuItem menuItem = GetMenuItemByMealNumber(originalMenuNumber);

            // Delete the MenuItem
                // if cannot locate by MenuNumber, return false
            if (menuItem == null)
            {
                return false; // returns false if cannot find MenuItem by MealNumber in _listOfMenuItems
            }

                // create Count of MenuItems on list to compare FIRST & THEN remove the MenuItem
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItem);

                // compare the initial count to a new count after removal to verify removal
            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper Methods

        //      - Get MenuItem by MealNumber
        public MenuItem GetMenuItemByMealNumber(int mealNumber)
        {
            foreach (MenuItem individualMenuItem in _listOfMenuItems)
            {
                if (individualMenuItem.MealNumber == mealNumber)
                {
                    return individualMenuItem;
                }
            }
            return null;
        }
    }
}
