using Challenge2_Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Challenge2_Library.Type;

namespace Challenge2

{
    class Challenge2_UI
    {
        //create private repository for menu
        private ClaimRepo _claimRepo = new ClaimRepo();

        //Run & Seed
        public void Run()
        {
            Console.WindowWidth = 175; // set console window size to wider than default to properly display table of data
            SeedListOfClaims();
            Menu();
        }

        //Menu
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                /* Menu Setup :
                 * 1 - See all claims
                 * 2 - Take care of next claim
                 * 3 - Enter new claim
                 * */

                // Display MENU options


                Console.WriteLine("Komodo Insurance Claim Management\n" +
                    "\n" +
                    "Choose an option from the menu below:\n" +
                    "1 : See all claims\n" +
                    "2 : Take care of next claim\n" +
                    "3 : Enter new claim\n" +
                    "4 : EXIT");

                //Capture User INPUT
                var input = Console.ReadLine().ToUpper();
                //Evaulate user INPUT
                switch (input)
                {
                    case "1":

                        Console.Clear();
                        DisplayConvertedQueueToDataTable();
                        break;

                    case "2":
                        Console.WriteLine("Display next claim? Y/N");
                        var selection1 = Console.ReadLine().ToUpper();
                        if (selection1 == "Y")
                        {
                            Console.Clear();
                            TakeCareOfNextClaim();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }

                    case "3":

                        Console.WriteLine("To ADD a new claim, press Y, otherwise, press any key to return to the main menu...");
                        var selection2 = Console.ReadLine().ToUpper();

                        if (selection2 == "Y")
                        {
                            CreateNewClaimAndAddToQueueOfClaims();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }

                    case "4":
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

        //SEE (show queue of) all claims
        public void SeeQueueOfClaimsUnformatted()// Unformatted claim data for functionality testing
        {
            //Unformatted (not in data table)

            Queue<Claim> queueOfClaims = _claimRepo.ShowQueueofClaims();
            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine($"Claim ID Number {claim.ClaimId} // Type: {claim.ClaimType} // Description: {claim.ClaimDescription} // Amount: ${claim.ClaimDescription} // Date Occurred : {claim.DateOfIncident} // Date Submitted : {claim.DateOfClaim} // Valid : {claim.ClaimIsValid}\n");
                
                // Below can be used to give a total of entries in queue since there is not indexing ability for queues
                // int claimCount= queueOfClaims.ToArray().ToList().IndexOf(claim);
              
            }
            


        }
        public void DisplayConvertedQueueToDataTable()
        {
            // Get queue populated with claim data
            Queue<Claim> queueOfClaims = _claimRepo.ShowQueueofClaims();
            // make new DATATABLE
            DataTable dt = new DataTable();

            // add COLUMNS with column types
            dt.Columns.Add("ID");
            dt.Columns.Add("Type");
            dt.Columns.Add("Description");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Date Occurred");
            dt.Columns.Add("Date Submitted");
            dt.Columns.Add("IsValid");

            // for each claim in the queue, make a new ROW and and put correct property under correct column type
            foreach (var claim in queueOfClaims)
            {
                // make the new row 
                var row = dt.NewRow();

                // row elements to fall under column headers
                row["ID"] = $"{claim.ClaimId}";
                row["Type"] = $"{claim.ClaimType}";
                row["Description"] = $"{claim.ClaimDescription}";
                row["Amount"] = $"${claim.ClaimAmount}";
                row["Date Occurred"] = $"{claim.DateOfIncident.ToShortDateString()}";
                row["Date Submitted"] = $"{claim.DateOfClaim.ToShortDateString()}";
                row["IsValid"] = $"{claim.ClaimIsValid}";

                // add the row to the data table
                dt.Rows.Add(row);

            }

            //use the method below to print to the console the data table
            ShowFormattedQueueDataTable(dt);
            Console.WriteLine("\n" +
                "\n" +
                "Press any key to return to main menu...");
            Console.ReadLine();
            Console.Clear();


        }

        private void ShowFormattedQueueDataTable(DataTable table) // print data table of queue info to console (object is in the DataTable made above)
        {
            //Print header to label columns with spaces & tabs
            Console.WriteLine("{0,7} \t {1,6} \t {2,25} \t {3,8} \t {4,15} \t {5,15} \t {6,8}", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");

            //Print rows to fall under column heading with spaces & tabs
            foreach (DataRow row in table.Rows) //(Var didn't work - must be DataRow class)
            {
                Console.WriteLine("{0,7} \t {1,6} \t {2,25} \t {3,8} \t {4,15} \t {5,15} \t {6,8}",
                    row["ID"],
                row["Type"],
                row["Description"],
                row["Amount"],
                row["Date Occurred"],
                row["Date Submitted"],
                row["IsValid"]);
            }
        }

        //Take (PEEK) care of next claim - DOES NOT REMOVE FROM QUEUE (change to dequeu to remove)
        public void TakeCareOfNextClaimUnformatted() //UNFORMATTED data for testing functionality
        {
            // get queue and check to see if queue has entries to avoid null exception error
            Queue<Claim> queueOfClaims = _claimRepo.ShowQueueofClaims();
            if (queueOfClaims.Count >= 1)
            {
                var claim = new Claim();
                claim = queueOfClaims.Peek();
                Console.WriteLine($"Next Claim to handle:\n " +
                    $"Claim ID Number {claim.ClaimId} // Type: {claim.ClaimType} // Description: {claim.ClaimDescription} // Amount: {claim.ClaimDescription} // Date Occurred : {claim.DateOfIncident} // Date Submitted : {claim.DateOfClaim} // Valid : {claim.ClaimIsValid}\n");
                Console.WriteLine("Press any key to return to Main Menu...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Claims queue is currently empty.");
            }
        }
        public void TakeCareOfNextClaim()
        {
            // get queue and check to see if queue has entries to avoid null exception error
            Queue<Claim> queueOfClaims = _claimRepo.ShowQueueofClaims();
            if (queueOfClaims.Count >= 1)
            {
                Console.WriteLine($"Next Claim to handle:\n ");

                var claim = new Claim();
                claim = queueOfClaims.Peek(); //.PEEK as opposed to .DEQUEUE (claim = queueOfClaims.Dequeue();) display and pull oldest queue entry.

                // make new DATATABLE
                DataTable dt = new DataTable();

                // add COLUMNS with column types
                dt.Columns.Add("ID");
                dt.Columns.Add("Type");
                dt.Columns.Add("Description");
                dt.Columns.Add("Amount");
                dt.Columns.Add("Date Occurred");
                dt.Columns.Add("Date Submitted");
                dt.Columns.Add("IsValid");

                // for first PEEK'ed claim in the queue, make a new ROW and and put correct property under correct column type
                var row = dt.NewRow();

                // row elements to fall under column headers
                row["ID"] = $"{claim.ClaimId}";
                row["Type"] = $"{claim.ClaimType}";
                row["Description"] = $"{claim.ClaimDescription}";
                row["Amount"] = $"${claim.ClaimAmount}";
                row["Date Occurred"] = $"{claim.DateOfIncident.ToShortDateString()}";
                row["Date Submitted"] = $"{claim.DateOfClaim.ToShortDateString()}";
                row["IsValid"] = $"{claim.ClaimIsValid}";

                // add the row to the data table
                dt.Rows.Add(row);

                //use the method below to print to the console the data table
                ShowFormattedQueueDataTable(dt);

                // User input to DEQUEU ("deal with claim")
                Console.WriteLine("Do you wish to deal with this claim now? Y/N ");
                var inputForNextClaim = Console.ReadLine().ToUpper();
                if(inputForNextClaim == "Y")
                {
                    claim = queueOfClaims.Dequeue();
                    Console.WriteLine("Claim removed from queue...");
                }
                else if (inputForNextClaim == "N")
                {
                    Console.WriteLine("Claim returned to queue..");
                }
                else
                {
                    Console.WriteLine("Invalid entry.");
                }

                Console.WriteLine("\n" +
                    "\n" +
                    "Press any key to return to main menu...");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Claims queue is currently empty.");
            }
        }

        public void DisplayConvertedQueueToDataTableForNewClaimCreation()// Slightly modified display for formatting for new claim method
        {
            // Get queue populated with claim data
            Queue<Claim> queueOfClaims = _claimRepo.ShowQueueofClaims();
            // make new DATATABLE
            DataTable dt = new DataTable("Current Claims");

            // add COLUMNS with column types
            dt.Columns.Add("ID");
            dt.Columns.Add("Type");
            dt.Columns.Add("Description");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Date Occurred");
            dt.Columns.Add("Date Submitted");
            dt.Columns.Add("IsValid");

            // for each claim in the queue, make a new ROW and and put correct property under correct column type
            foreach (var claim in queueOfClaims)
            {
                // make the new row 
                var row = dt.NewRow();

                // row elements to fall under column headers
                row["ID"] = $"{claim.ClaimId}";
                row["Type"] = $"{claim.ClaimType}";
                row["Description"] = $"{claim.ClaimDescription}";
                row["Amount"] = $"${claim.ClaimAmount}";
                row["Date Occurred"] = $"{claim.DateOfIncident.ToShortDateString()}";
                row["Date Submitted"] = $"{claim.DateOfClaim.ToShortDateString()}";
                row["IsValid"] = $"{claim.ClaimIsValid}";

                // add the row to the data table
                dt.Rows.Add(row);

            }

            //use the method below to print to the console the data table
            ShowFormattedQueueDataTable(dt);
            Console.WriteLine("\n" +
                "\n");
        }

        //ENTER & ADD new claim to queue
        public void CreateNewClaimAndAddToQueueOfClaims()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Create new CLAIM
                var newClaim = new Claim();

                //Display the QUEUE of claims
                Console.Clear();
                DisplayConvertedQueueToDataTableForNewClaimCreation();

                Console.WriteLine("\nENTERING NEW CLAIM : \n");

                //Get user input for claim number, check to make sure is int, then convert or get new input
                bool keepRunningConvertClaimNumber = true;
                while (keepRunningConvertClaimNumber)
                {
                    Console.WriteLine("Please enter a claim NUMBER:\n");
                    var claimNumberInput = Console.ReadLine();
                    //check to see if input can be converted to int
                    int num = -1;
                    if (!int.TryParse(claimNumberInput, out num))
                    {
                        Console.WriteLine("Please enter a valid number... ");
                    }
                    else
                    {
                        var convertedClaimNumberInput = Convert.ToInt32(claimNumberInput);
                        newClaim.ClaimId = convertedClaimNumberInput;
                        keepRunningConvertClaimNumber = false;
                    }
                }

                bool keepRunningTwo = true;
                while (keepRunningTwo)
                {
                    Console.WriteLine("Please enter a claim TYPE - CAR, HOME, or THEFT :\n");
                    string claimTypeInput = Console.ReadLine().ToUpper();

                    switch (claimTypeInput)
                    {
                        case "CAR":
                            newClaim.ClaimType = Type.Car;
                            keepRunningTwo = false;
                            break;
                        case "HOME":
                            newClaim.ClaimType = Type.Home;
                            keepRunningTwo = false;
                            break;
                        case "THEFT":
                            newClaim.ClaimType = Type.Theft;
                            keepRunningTwo = false;
                            break;
                        default:
                            Console.WriteLine("Please enter CAR, HOME, or THEFT...");
                            break;
                    }
                }

                Console.WriteLine("Please enter a short description of the claim incident, then hit enter :\n");
                string claimDescriptionInput = Console.ReadLine();
                newClaim.ClaimDescription = claimDescriptionInput;

                Console.WriteLine("Please enter a total dollar amount of the claim : \n");
                //Get user input for claim number, check to make sure is double, then convert or get new input
                bool keepRunningConvertClaimAmount = true;
                while (keepRunningConvertClaimAmount)
                {
                    Console.WriteLine("Please enter a claim AMOUNT:\n");
                    var claimAmountInput = Console.ReadLine();
                    //check to see if input can be converted to double
                    double num = -1;
                    if (!double.TryParse(claimAmountInput, out num))
                    {
                        Console.WriteLine("Please enter a valid amount... ");
                    }
                    else
                    {
                        var convertedClaimAmountInput = Convert.ToDouble(claimAmountInput);
                        newClaim.ClaimAmount = convertedClaimAmountInput;
                        keepRunningConvertClaimAmount = false;
                    }
                }

                // Set variable for use in DateTime formatting
                var usCulture = new System.Globalization.CultureInfo("en-US");
        
                bool keepRunningDateOccurred = true;
                while (keepRunningDateOccurred)
                {
                    Console.WriteLine("Please enter the DATE the claim incident OCCURRED in the following format : " + usCulture.DateTimeFormat.ShortDatePattern);
                    var claimDateOccurred = Console.ReadLine();
                    DateTime userDateOccurred;

                    // Run check to make sure entered DATETIME is in correct format
                    if (DateTime.TryParse(claimDateOccurred, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out userDateOccurred))
                    {
                        newClaim.DateOfIncident = userDateOccurred;
                        keepRunningDateOccurred = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date entry. Enter a date in the format 01/01/2020");
                    }
                }

                bool keepRunningDateSubmitted = true;
                while (keepRunningDateSubmitted)
                {
                    Console.WriteLine("Please enter the DATE the claim was SUBMITTED in the following format : " + usCulture.DateTimeFormat.ShortDatePattern);
                    var claimDateSubmitted = Console.ReadLine();
                    DateTime userDateSubmitted;

                    // Run check to make sure entered DATETIME is in correct format
                    if (DateTime.TryParse(claimDateSubmitted, usCulture.DateTimeFormat, System.Globalization.DateTimeStyles.None, out userDateSubmitted))
                    {
                        newClaim.DateOfClaim = userDateSubmitted;
                        keepRunningDateSubmitted = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date entry. Enter a date in the format 01/01/2020");
                    }
                }

                // Subtract date entries, check to be <= 30 days
                var totalDaysBetweenOccurredSubmitted = (newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays;
                if (totalDaysBetweenOccurredSubmitted <= 30)
                {
                    newClaim.ClaimIsValid = true;
                    Console.WriteLine("Claim was submitted 30 days or less after incident.\n" +
                        "Claim is VALID.");
                    _claimRepo.AddClaimToQueue(newClaim);
                }
                else
                {
                    newClaim.ClaimIsValid = false;
                    Console.WriteLine("Claim was submitted more than 30 days after incident.\n" +
                        "Claim is NOT VALID.");
                    _claimRepo.AddClaimToQueue(newClaim);
                }

                Console.WriteLine("Would you like to enter another claim?");
                var input = Console.ReadLine().ToUpper();
                if (input == "N")
                {
                    Console.Clear();
                    keepRunning = false;
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        //SEED Claims
        private void SeedListOfClaims()
        {
            //DateTime date1 = DateTime.Parse(04/25/2018);

            Claim claim1 = new Claim(1, Type.Car, "Car accident on 465", 400.00, Convert.ToDateTime("2018, 04, 25"), Convert.ToDateTime("2018/ 04/ 27"), true);
            Claim claim2 = new Claim(2, Type.Home, "House fire in kitchen", 4000.00, Convert.ToDateTime("2018/ 04/ 11"), Convert.ToDateTime("2018/ 04/ 12"), true);
            Claim claim3 = new Claim(3, Type.Theft, "Stolen pancakes", 4.00, Convert.ToDateTime("2018/ 04/ 27"), Convert.ToDateTime("2018/ 06/ 01"), false);
            

            _claimRepo.AddClaimToQueue(claim1);
            _claimRepo.AddClaimToQueue(claim2);
            _claimRepo.AddClaimToQueue(claim3);

        }
    }
}
