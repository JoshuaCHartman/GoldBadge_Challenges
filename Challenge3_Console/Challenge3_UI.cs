using Challenge3_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3_Console
{
    class Challenge3_UI
    {
        private BadgeRepo _badgerepo = new BadgeRepo();

        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }

        /* Menu options:
         * 1 See list of all badges w/ respective door access (table format)
         * 2 Create new badge (create number (maybe make sequential w/an override?), add doors) (loop)
         * 3 Update door access for indivual badge
         *      - Add doors (loop)
         *      - Delete doors (loop)
         * 4 Delete (revoke) all door access for individual badge
         * 5 Exit*/

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display MENU options

                Console.WriteLine("Komodo Insurance Badge Management\n" +
                    "\n" +
                    "Choose an option from the menu below:\n" +
                    "1 : See all BADGES with Door Access\n" +
                    "2 : Create new BADGE\n" +
                    "3 : Update DOOR access for an individual badge\n" +
                    "4 : Delete all DOOR access from an individual badge\n" +
                    "5 : EXIT");

                //Capture User INPUT
                var input = Console.ReadLine().ToUpper();
                //Evaulate user INPUT
                switch (input)
                {
                    case "1": // See all badges and door numbers

                        Console.Clear();
                        ShowAllBadgesWithDoorAccess();
                        ReturnToMainMenuAndClear();
                        break;

                    case "2": // Add Badge

                        Console.Clear();
                        ShowAllBadgesWithDoorAccess();

                        Console.WriteLine("To ADD a new badge, press Y, otherwise, press any key to return to the main menu...");
                        var selection1 = Console.ReadLine().ToUpper();

                        if (selection1 == "Y")
                        {
                            CreateNewBadge();
                            ReturnToMainMenuAndClear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }

                    case "3":// Update door access

                        Console.Clear();
                        ShowAllBadgesWithDoorAccess();

                        Console.WriteLine("To update door access, press Y, otherwise, press any key to return to the main menu...");
                        var selection2 = Console.ReadLine().ToUpper();

                        if (selection2 == "Y")
                        {

                            GetBadgesListOfDoorsAndEditDoors();
                            ReturnToMainMenuAndClear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }

                    case "4":

                        Console.Clear();
                        ShowAllBadgesWithDoorAccess();

                        Console.WriteLine("To remove all door access from a badge, press Y, otherwise, press any key to return to the main menu...");
                        var selection3 = Console.ReadLine().ToUpper();

                        if (selection3 == "Y")
                        {
                            DeleteAllDoorsFromOneBadge();
                            ReturnToMainMenuAndClear();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }

                    case "5":
                        string exitText = "EXITING .......";
                        foreach (char c in exitText)
                        {
                            Console.Write(c); // write one char at a time
                            System.Threading.Thread.Sleep(35); //sleeps between characters to slow down write speed
                        }
                        keepRunning = false;
                        break;

                    default:
                        break;
                }

            }
        }
        public void CreateNewBadge()
        {
            var newBadge = new Badge();
            List<string> newBadgeDoorList = new List<string>();

            bool keepRunning1 = true;
            while (keepRunning1)
            {
                Console.WriteLine("Enter a new badge ID number (example: 11010) :");
                var inputID = Console.ReadLine();

                //check to ensure input can be converted to int
                int num = -1;
                if (!int.TryParse(inputID, out num))
                {
                    Console.WriteLine("Please enter a valid number... ");
                }
                else
                {
                    var convertedBadgeNumberInput = Convert.ToInt32(inputID);

                    //check against dictionary keys and ensure != 0, if ok sets ID as badge property
                    Dictionary<int, Badge> dictionaryOfBadges = _badgerepo.ShowAllBadges();

                    if (dictionaryOfBadges.ContainsKey(convertedBadgeNumberInput) || convertedBadgeNumberInput == 0)
                    {
                        Console.WriteLine("Please enter a badge ID number not currently in use and not 0 ...");
                    }
                    else
                    {
                        newBadge.BadgeID = convertedBadgeNumberInput;
                        keepRunning1 = false;
                    }
                }
            }

            bool keepRunning2 = true;
            while (keepRunning2)
            {
                //add door loop
                Console.WriteLine($"Enter a door for {newBadge.BadgeID} to access (example A110):");
                string inputDoor = Console.ReadLine().ToUpper();
                newBadgeDoorList.Add(inputDoor);
                Console.WriteLine("Would you like to enter additional doors? Y/N");
                var inputDoorAddLoop = Console.ReadLine().ToUpper();
                if (inputDoorAddLoop == "N")
                {
                    //add list of door to badge
                    newBadge.ListOfDoors = newBadgeDoorList;
                    //add badge to dictionary using ID property as key
                    _badgerepo.AddBadgeToDictionary(newBadge.BadgeID, newBadge);

                    //Print new badge ID w/doors
                    Console.WriteLine($"Badge ID {newBadge.BadgeID} added with access to doors: ");
                    foreach (string door in newBadgeDoorList)
                    {
                        Console.Write(door + " ");
                    }
                    Console.Write("\n");
                    keepRunning2 = false;
                }
                else
                {

                }

            }
        }

        public void GetBadgesListOfDoorsAndEditDoors()
        {
            Dictionary<int, Badge> dictionaryOfBadges = _badgerepo.ShowAllBadges();

            Console.WriteLine("Enter a badge ID number (example: 11010) :");
            bool keepRunning = true;
            while (keepRunning)
            {
                var inputID = Console.ReadLine();

                //check to ensure input can be converted to int
                int num = -1;
                if (!int.TryParse(inputID, out num))
                {
                    Console.WriteLine("Please enter a valid number... ");
                }
                else
                {
                    var convertedBadgeNumberInput = Convert.ToInt32(inputID);
                    bool idExists = dictionaryOfBadges.ContainsKey(convertedBadgeNumberInput);

                    //check if 0, asks for new input

                    if (convertedBadgeNumberInput == 0)
                    {
                        Console.WriteLine("Please enter a valid number... ");
                    }
                    else if (idExists == false)  //No key found
                    {
                        Console.WriteLine("Badge ID does not exist.");
                        keepRunning = false;

                    }
                    else //if key found
                    {
                        //display badge and doors

                        var badgeToEdit = dictionaryOfBadges[convertedBadgeNumberInput];
                        Console.Write($"Badge Number:\t\t Door Access:\n");
                        Console.Write($"Badge number :{badgeToEdit.BadgeID}\t Access :");
                        foreach (string door in badgeToEdit.ListOfDoors)
                        {
                            Console.Write(door + " ");
                        }
                        Console.Write("\n");

                        // loop for editing multiple doors
                        bool keepRunning2 = true;
                        while (keepRunning2)
                        {
                            // choose an option to edit doors
                            Console.WriteLine("Enter an option to ADD or DELETE a door:\n" +
                            "1 : ADD door\n" +
                            "2 : DELETE door\n");

                            var inputChoice = Console.ReadLine();

                            //check to ensure input can be converted to int
                            int num1 = -1;
                            if (!int.TryParse(inputChoice, out num1))
                            {
                                Console.WriteLine("Please enter a valid number... ");
                            }
                            else
                            {
                                var convertedInputChoice = Convert.ToInt32(inputChoice);
                                switch (convertedInputChoice)
                                {
                                    case 1:
                                        Console.WriteLine($"Enter a door for {badgeToEdit.BadgeID} to access (example A110):");
                                        string inputDoorAdd = Console.ReadLine().ToUpper();
                                        if (badgeToEdit.ListOfDoors.Contains(inputDoorAdd))
                                        {
                                            Console.WriteLine("Door access already granted.");
                                            break;
                                        }
                                        else 
                                        {
                                            badgeToEdit.ListOfDoors.Add(inputDoorAdd);
                                            break;
                                        }

                                    case 2:
                                        Console.WriteLine($"Enter a door to remove from {badgeToEdit.BadgeID}:");
                                        string inputDoorDelete = Console.ReadLine().ToUpper();
                                        if (badgeToEdit.ListOfDoors.Contains(inputDoorDelete))
                                        {
                                            badgeToEdit.ListOfDoors.Remove(inputDoorDelete);
                                        }
                                        else
                                        { }
                                        break;

                                    default:

                                        break;
                                }

                                //question about editing another door and change loop variable if not
                                Console.WriteLine("To continue to update door access, press Y, otherwise, press any key to return to the main menu...");
                                var selection2 = Console.ReadLine().ToUpper();
                                if (selection2 != "Y")
                                {
                                    Console.Write($"Badge number {badgeToEdit.BadgeID} can now access doors: ");
                                    foreach (string door in badgeToEdit.ListOfDoors)
                                    {
                                        Console.Write(door + " ");
                                    }
                                    Console.Write("\n");
                                    keepRunning2 = false;
                                    keepRunning = false;
                                }
                                else
                                { }

                                Console.Write("\n");

                            }

                        }
                    }
                }
            }
        }

        public void DeleteAllDoorsFromOneBadge()
        {
            Dictionary<int, Badge> dictionaryOfBadges = _badgerepo.ShowAllBadges();

            Console.WriteLine("Enter a badge ID number (example: 11010) :");
            bool keepRunning = true;
            while (keepRunning)
            {
                var inputID = Console.ReadLine();

                //check to ensure input can be converted to int
                int num = -1;
                if (!int.TryParse(inputID, out num))
                {
                    Console.WriteLine("Please enter a valid number... ");
                }
                else
                {
                    var convertedBadgeNumberInput = Convert.ToInt32(inputID);
                    bool idExists = dictionaryOfBadges.ContainsKey(convertedBadgeNumberInput);

                    //check if 0, asks for new input

                    if (convertedBadgeNumberInput == 0)
                    {
                        Console.WriteLine("Please enter a valid number from the list above:  ");
                    }
                    else if (idExists == false)  //No key found
                    {
                        Console.WriteLine("Badge ID does not exist.\n" +
                            "Please enter a valid badge number from the list above: ");
                    }
                    else //if key found
                    {
                        //display badge and doors

                        var badgeToEdit = dictionaryOfBadges[convertedBadgeNumberInput];
                        Console.Write($"Badge Number:\t\t Door Access:\n");
                        Console.Write($"Badge number :{badgeToEdit.BadgeID}\t Access :");
                        foreach (string door in badgeToEdit.ListOfDoors)
                        {
                            Console.Write(door + " ");
                        }
                        Console.Write("\n");

                        Console.WriteLine("Remove all doors from this badge? Y/N");
                        var input2 = Console.ReadLine().ToUpper();
                        switch (input2)
                        {
                            case"Y":
                                badgeToEdit.ListOfDoors.Clear();
                                Console.Write($"Badge Number:\t\t Door Access:\n");
                                Console.Write($"Badge:{badgeToEdit.BadgeID}\t\t ");
                                foreach (string door in badgeToEdit.ListOfDoors)
                                {
                                    Console.Write(door + " ");
                                }
                                Console.Write("\n");
                                keepRunning = false;
                                break;
                            default:
                                keepRunning = false;
                                break;
                        }
                    }
                }
            }
        }

        public void ShowAllBadgesWithDoorAccess()
        {
            Dictionary<int, Badge> dictionaryOfBadges = _badgerepo.ShowAllBadges();
            Console.Write($"Badge Number:\t\t Door Access:\n");
            foreach (var pair in dictionaryOfBadges)
            {
                Console.Write($"Badge {pair.Value.BadgeID}\t\t ");//Join method - more efficient but have to change formatting {string.Join(" ",  pair.Value.ListOfDoors)}"); 
                foreach (string door in pair.Value.ListOfDoors)
                {
                    Console.Write(door + " ");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        public void ReturnToMainMenuAndClear()
        {
            Console.WriteLine("Press any key to return to main menu ...");
            Console.ReadLine();
            Console.Clear();
        }
        private void SeedBadgeDictionary()
        {
            //Lists of doors
            var badegeList1 = new List<string>();
            var badegeList2 = new List<string>();
            var badegeList3 = new List<string>();
            var badegeList4 = new List<string>();
            var badegeList5 = new List<string>();

            //Potential doors :A110 - A150
            badegeList1.Add("A110");
            badegeList1.Add("A111");
            badegeList1.Add("A112");
            badegeList1.Add("A113");
            badegeList1.Add("A114");

            badegeList2.Add("A110");
            badegeList2.Add("A111");
            badegeList2.Add("A120");
            badegeList2.Add("A121");
            badegeList2.Add("A122");

            badegeList3.Add("A110");
            badegeList3.Add("A130");
            badegeList3.Add("A131");
            badegeList3.Add("A132");
            badegeList3.Add("A134");

            badegeList4.Add("A110");
            badegeList4.Add("A111");
            badegeList4.Add("A120");
            badegeList4.Add("A130");
            badegeList4.Add("A140");

            badegeList5.Add("A110");
            badegeList5.Add("A111");
            badegeList5.Add("A130");
            badegeList5.Add("A131");
            badegeList5.Add("A145");


            //Set key variable = int badgeID in Badge object
            int key01 = 11011;
            int key02 = 11012;
            int key03 = 11013;
            int key04 = 11014;
            int key05 = 11015;

            //Badge objects
            var badge1 = new Badge(key01, badegeList1);
            var badge2 = new Badge(key02, badegeList2);
            var badge3 = new Badge(key03, badegeList3);
            var badge4 = new Badge(key04, badegeList4);
            var badge5 = new Badge(key05, badegeList5);

            //Add pairs to dictionary

            _badgerepo.AddBadgeToDictionary(key01, badge1);
            _badgerepo.AddBadgeToDictionary(key02, badge2);
            _badgerepo.AddBadgeToDictionary(key03, badge3);
            _badgerepo.AddBadgeToDictionary(key04, badge4);
            _badgerepo.AddBadgeToDictionary(key05, badge5);

        }
    }
}
