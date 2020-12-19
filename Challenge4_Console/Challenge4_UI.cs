using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge4_Console
{
    class Challenge4_UI
    {
        public void Run()
        {
            SeedEvents();
            Console.WindowWidth = 175;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Menu();
        }

        public void Menu()
        {
            /* Menu options:
             * 1 - Display all outings (data table)
             * 2 - Add an outing (confirm with data table row)
             * 3 - Calculations
             *      - A - Total Cost of events by type
             *      - B - Total Cost of ALL events
            */

            string menuText = ("Komodo Event Mangement\n" +
                        "Menu options:\n" +
                        "1 - Display all outings(data table)\n" +
                        "2 - Add an outing\n" +
                        "3 - Calculations\n" +
                        "4 - Exit\n"+
                        "\n"+
                        "Please enter a selection : \n");
            var newMenu = centerText(menuText);
            Console.WriteLine(newMenu);
            Console.ReadLine();

            string menuInput = Console.ReadLine();
            var convertedMenuInput = ConvertUserInputToInteger(menuInput);

            switch (convertedMenuInput)
            {
                case 1:
                        break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;

            }


        }
        public int ConvertUserInputToInteger(string userInput)
        {
            
                int num;
                if (int.TryParse(userInput, out num))
                {
                return num;
                }
                else
                {
                Console.WriteLine("Invalid input. Please enter a number for your selection: \n");
                }
                
        }

        static string centerText(string text)
        {
            return new string(' ', (Console.WindowWidth - text.Length) / 2) + text;
        }
       
        public void SeedEvents()
        {

        }

    }
}
