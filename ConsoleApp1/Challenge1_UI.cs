using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge1;
using Challenge1_Library;




namespace Challenge1
{
    class Challenge1_UI
    {
        // create private Menu repository
        private MenuItemRepo _menuItemRepo = new MenuItemRepo();


        //Run method to start UI from program
        public void Run()
        {
            SeedListOfMeals();
            Menu();
        }

        public void Menu()
        {
            /* Menu setup:
             * 1 - See list of Meals
             * 2 - Build a new Meal
             * 3 - Modify an existing Meal
             * 4 - Remove a Meal
             * 5 - Exit
             * */
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display Menu options
                Console.WriteLine("Meal Menu\n" +
                    "Please choose an option from the list below:\n" +
                    "1 : See list of Meals\n" +
                    "2 : Build a new Meal\n" +
                    "3 : Modify an existing Meal\n" +
                    "4 : Remove an existing Meal\n" +
                    "5 : EXIT");

                //Capture user input
                string input = Console.ReadLine();
                //Evaluate user input
                switch (input)
                {
                    case "1": // See list of meals cRud
                        ShowListOfMeals();
                        break;

                    case "2": // Create new meal Crud
                        CreateNewMeal();
                        break;

                    case "3": // Update existing meal crUd 
                        UpdateMeal();
                        break;

                    case "4": // Delete existing meal cruD 
                        DeleteMeal();
                        break;

                    case "5": // Exit
                        string exitText = "EXITING .............";
                        foreach (char c in exitText)
                        {
                            Console.Write(c); // write one char at a time
                            System.Threading.Thread.Sleep(35); //sleeps between characters to slow down write speed
                        }
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid selection : 1-5");
                        break;
                }
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear(); // clear screen while running
            }

        }

        public void ShowListOfMeals()
        {

            List<MenuItem> listOfMeals = _menuItemRepo.GetMenuItemList();
            Console.Clear();
            foreach (MenuItem menuItem in listOfMeals)
            {
                Console.WriteLine($"Meal Number: {menuItem.MealNumber} Price: ${menuItem.MealPrice}\n" +
                    $"{menuItem.MealName}: {menuItem.MealDescription}\n" +
                    $"Ingredients: ");
                foreach (string ingredient in menuItem.MealIngredients)
                {
                    Console.Write($"{ingredient}/ ");
                }
                Console.WriteLine("\n");

            }

        }
        // UPDATE CREATE AND UPDATE METHODS TO NOT THROW EXCEPTIONS - USE FROM CHALLENGE 2
        public void CreateNewMeal()
        {
            Console.Clear();
            ShowListOfMeals();
            MenuItem newMenuItem = new MenuItem();

            // Enter info for single variables
            Console.WriteLine("Adding New Meal...\n");

            // Meal Number
            Console.WriteLine("Please enter a meal NUMBER:\n");
            bool keepRunningConvertMealNumber = true;
            while (keepRunningConvertMealNumber)
            {
                var newNumber = Console.ReadLine();
                //check to see if input can be converted to int
                int num = -1;
                if (!int.TryParse(newNumber, out num))
                {
                    Console.WriteLine("Please enter a valid number... ");
                }
                else
                {
                    var convertedMealNumber = Convert.ToInt32(newNumber);
                    newMenuItem.MealNumber = convertedMealNumber;
                    keepRunningConvertMealNumber = false;
                }
            }

            // Meal Name
            Console.WriteLine("Enter meal NAME : ");
            string newName = Console.ReadLine();
            newMenuItem.MealName = newName;

            // Meal Description
            Console.WriteLine("Enter a meal DESCRIPTION :");
            string newDescription = Console.ReadLine();
            newMenuItem.MealDescription = newDescription;

            // Meal Price
            Console.WriteLine("Enter a meal PRICE :");
            bool keepRunningConvertMenuPrice = true;
            while (keepRunningConvertMenuPrice)
            {
                var newPrice = Console.ReadLine();
                //check to see if input can be converted to double
                double num = -1;
                if (!double.TryParse(newPrice, out num))
                {
                    Console.WriteLine("Please enter a valid amount... ");
                }
                else
                {
                    var convertedMealPrice = Convert.ToDouble(newPrice);
                    newMenuItem.MealPrice = convertedMealPrice;
                    keepRunningConvertMenuPrice = false;
                }
            }

            // Add ingredients to list property
            List<string> ingredientList = new List<string>();
            newMenuItem.MealIngredients = ingredientList;
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Would you like to add an ingredient? Y/N ");
                var input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    Console.WriteLine("Enter ingredient (example: cheesburger, side of fries, fountain drink, etc");
                    var ingredient = Console.ReadLine();
                    ingredientList.Add(ingredient);
                }
                else
                {
                    keepRunning = false;
                }
            }
            // add new entry to menu
            _menuItemRepo.AddMenuItemToList(newMenuItem);
        }
        public void UpdateMeal()
        {
            //Display content
            Console.Clear();
            ShowListOfMeals();

            MenuItem newMenuItem = new MenuItem();

            //Get individual meal method
            Console.WriteLine("Enter the NUMBER of the meal you would like to update: ");
            var newNumber = Console.ReadLine();
            // Meal Number
            bool keepRunningConvertMealNumber = true;
            while (keepRunningConvertMealNumber)
            {
                //check to see if input can be converted to int
                int num = -1;
                if (!int.TryParse(newNumber, out num))
                {
                    Console.WriteLine("Please enter a valid number... ");
                }
                else
                {

                    keepRunningConvertMealNumber = false;
                }
            }
            // Enter info override single properties

            //Meal Number not changed
            var convertedMealNumber = Convert.ToInt32(newNumber);
            MenuItem oldmenuItem = _menuItemRepo.GetMenuItemByMealNumber(convertedMealNumber);
            newMenuItem.MealNumber = convertedMealNumber;

            Console.WriteLine("Updating Meal...\n" +
            "Please enter meal Name :");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter a meal DESCRIPTION :");
            newMenuItem.MealDescription = Console.ReadLine();

            // Meal Price
            Console.WriteLine("Enter a meal PRICE :");
            bool keepRunningConvertMenuPrice = true;
            while (keepRunningConvertMenuPrice)
            {
                var newPrice = Console.ReadLine();
                //check to see if input can be converted to double
                double num = -1;
                if (!double.TryParse(newPrice, out num))
                {
                    Console.WriteLine("Please enter a valid amount... ");
                }
                else
                {
                    var convertedMealPrice = Convert.ToDouble(newPrice);
                    newMenuItem.MealPrice = convertedMealPrice;
                    keepRunningConvertMenuPrice = false;
                }
            }


            // Add ingredients to list property
            List<string> ingredientList = new List<string>();
            newMenuItem.MealIngredients = ingredientList;
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Would you like to add an ingredient? Y/N ");
                var input = Console.ReadLine().ToUpper();
                if (input == "Y")
                {
                    Console.WriteLine("Enter ingredient (example: cheesburger, side of fries, fountain drink, etc");
                    var ingredient = Console.ReadLine();
                    ingredientList.Add(ingredient);
                }
                else
                {
                    keepRunning = false;
                }
            }
            // add new entry to menu & verify
            bool wasUpdated = _menuItemRepo.UpdateMenuItem(oldmenuItem, newMenuItem);
            if (wasUpdated)
            {
                Console.WriteLine("Meal updated.");
            }
            else
            {
                Console.WriteLine("Could not update...");
            }

        }
        public void DeleteMeal()
        {
            Console.Clear();
            ShowListOfMeals();
            Console.WriteLine("Removing Meal:\n" +
                "Please enter a meal NUMBER :");
            var mealNumber = Convert.ToInt32(Console.ReadLine());

            // Delete and verify 
            bool wasUpdated=_menuItemRepo.DeleteMenuItemByMealNumber(mealNumber);
            if (wasUpdated)
            {
                Console.WriteLine("Meal removed.");
            }
            else
            {
                Console.WriteLine("Could not update...");
            }

        }
        private void SeedListOfMeals()
        {
            List<string> ingredientsMealOne = new List<string>();
            List<string> ingredientsMealTwo = new List<string>();
            List<string> ingredientsMealThree = new List<string>();

            MenuItem mealOne = new MenuItem(1, "The Standby", "A 1/4 pound cheeseburger on a classic hamburger roll, with a side of fries and a fountain drink", ingredientsMealOne, 4.99);
            MenuItem mealTwo = new MenuItem(2, "The Classic", "A large slice of NY style supreme pizza, served with three breadsticks and a fountain drink.", ingredientsMealTwo, 5.99);
            MenuItem mealThree = new MenuItem(3, "Kids' Food for Grownups", "Three crispy chicken fingers, served with a side of fries and a fountain drink.", ingredientsMealThree, 4.99);

            string one = "Cheeseburger";
            string two = "Side of Fries";
            string three = "Fountain Drink";
            string four = "Pizza Slice";
            string five = "Breadsticks";
            string six = "Chicken Fingers";
            ingredientsMealOne.Add(one);
            ingredientsMealOne.Add(two);
            ingredientsMealOne.Add(three);
            ingredientsMealTwo.Add(four);
            ingredientsMealTwo.Add(five);
            ingredientsMealTwo.Add(three);
            ingredientsMealThree.Add(six);
            ingredientsMealThree.Add(two);
            ingredientsMealThree.Add(three);

            _menuItemRepo.AddMenuItemToList(mealOne);
            _menuItemRepo.AddMenuItemToList(mealTwo);
            _menuItemRepo.AddMenuItemToList(mealThree);
        }

    }
}
