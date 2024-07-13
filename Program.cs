using ForAssignment1;
using System.Security.Cryptography.X509Certificates;

namespace OOP2_Assignment1
{
    internal class Program
    {
        // Declare the class-level appliance list here
        private static List<Appliance> applianceObjects = new List<Appliance>();

        static void Main(string[] args)
        {
            FormatApplianceTextFile();

            bool running = true;
            while (running)
            {
                MainMenu();
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CheckOutAppliance();
                        break;
                    case "2":
                        FindApplianceByBrand();
                        break;
                    case "3":
                        DisplayApplianceByType();
                        break;
                    case "4":
                        RandomApplianceList();
                        break;
                    case "5":
                        Console.WriteLine("Exit the System");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }
        }

        public static void FormatApplianceTextFile()
        {

            string applianceFile = "appliances.txt";
            string[] linesArray = File.ReadAllLines(applianceFile);
            List<string> lineList = new List<string>(linesArray);
            foreach (string line in lineList)
            {
                string[] appliance = line.Split(';');
                char applianceIdentifierChar = appliance[0][0];
                int applianceIdentifier = (int)char.GetNumericValue(applianceIdentifierChar);

                int itemNumber = int.Parse(appliance[0]);
                int quantity = int.Parse(appliance[2]);
                int wattage = int.Parse(appliance[3]);
                double price = double.Parse(appliance[5]);



                if (applianceIdentifier == 1)
                {
                    int numOfDoors = int.Parse(appliance[6]);
                    int height = int.Parse(appliance[7]);
                    int width = int.Parse(appliance[8]);

                    Refrigerator refrigerator = new Refrigerator(itemNumber, appliance[1], quantity, wattage, appliance[4], price, numOfDoors, height, width);
                    applianceObjects.Add(refrigerator);
                }

                if (applianceIdentifier == 2)
                {
                    int batteryVoltage = int.Parse(appliance[7]);

                    Vacuum vacuum = new Vacuum(itemNumber, appliance[1], quantity, wattage, appliance[4], price, appliance[6], batteryVoltage);
                    applianceObjects.Add(vacuum);
                }

                if (applianceIdentifier == 3)
                {
                    double capacity = double.Parse(appliance[6]);

                    Microwave microwave = new Microwave(itemNumber, appliance[1], quantity, wattage, appliance[4], price, capacity, appliance[7]);
                    applianceObjects.Add(microwave);
                }

                if (applianceIdentifier == 4 || applianceIdentifier == 5)
                {
                    Dishwasher dishwasher = new Dishwasher(itemNumber, appliance[1], quantity, wattage, appliance[4], price, appliance[6], appliance[7]);
                    applianceObjects.Add(dishwasher);
                }
            }
        }

        public static void CheckOutAppliance()
        {
            Console.WriteLine("\nEnter the item-number of an appliance:");
            int itemNumber = Convert.ToInt32(Console.ReadLine());

            bool searchFlag = false;
            foreach (Appliance appliance in applianceObjects)
            {
                if (appliance.ItemNumber == itemNumber)
                {
                    searchFlag = true;
                    // seperate into is quantity > 0

                    if (appliance.Quantity > 0)
                    {
                        //put logic for checking out item
                        
                        appliance.Quantity--;

                        Console.WriteLine($"\nAppliance \"{appliance.ItemNumber}\" has been checked out.\n");
                    }

                    else
                    {
                        Console.WriteLine("\nThe appliance is not available to be checked out.\n");
                    }
                }
            }
            if (searchFlag == false)
            {
                Console.WriteLine("\nNo appliances found with that item number.\n");
            }
        }

        public static void FindApplianceByBrand()
        {
            Console.WriteLine("\nEnter brand to search for:");
            string itemBrand = Console.ReadLine();

            foreach (Appliance appliance in applianceObjects)
            {
                if (appliance.Brand.Contains(itemBrand, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nMatching Appliances:\n" + appliance.ToString());
                }
            }
        }

        public static void DisplayApplianceByType()
        {

            Console.WriteLine("\nAppliance Types" +
                "\n1 - Refrigerators" +
                "\n2 - Vacuums" +
                "\n3 - Microwaves" +
                "\n4 - Dishwashers" +
                "\n\nEnter type of appliance: ");

            string option = Console.ReadLine();
            switch(option)
            {
                case "1":
                    Console.WriteLine("\nEnter number of doors: 2 (double door), 3 (three doors), or 4 (four doors):");

                    int doorNumSelection = Convert.ToInt32(Console.ReadLine());

                    DisplayDoorNumSelection(doorNumSelection);
                    break;

                case "2":
                    Console.WriteLine("\nEnter battery voltage value. 18v (low) or 24v (high)");

                    int batteryVoltageSelection = Convert.ToInt32(Console.ReadLine());

                    DisplayBatterVoltageSelection(batteryVoltageSelection);
                    break;

                case "3":
                    Console.WriteLine("\nRoom where the microwave will be installed: K (kitchen) or W (work site):");

                    string microwaveSite = Console.ReadLine();

                    DiaplaySelectMicrowaves(microwaveSite);
                    break;

                case "4":
                    Console.WriteLine("\nEnter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                    
                    string dishwasherSelection = Console.ReadLine();

                    DisplayDishwasherSelection(dishwasherSelection);
                    break;


                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }
            
        }

        public static void RandomApplianceList()
        {
            Console.WriteLine("\nEnter number of appliances:");
            int listLengthInt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            int count = 0;

            
            List<Appliance> listRandom = new List<Appliance>();
            listRandom.Clear();

            while (count < listLengthInt)
            {
                Random random = new Random();
                int randomIndex = random.Next(applianceObjects.Count);

                listRandom.Add(applianceObjects[randomIndex]);

                count++;
            }

            foreach (Appliance appliance in listRandom)
            {
                Console.WriteLine(appliance.ToString());
            }

        }

        public static void MainMenu()
        {
            Console.WriteLine("Welcome to Modern Appliances!\nHow may we assist you?" +
                "\n1 - Check out appliance" +
                "\n2 - Find appliances by brand" +
                "\n3 - Display appliances by type" +
                "\n4 - Produce random appliance list" +
                "\n5 - Save & exit" +
                "\n\nEnter option: ");
        }

        public static void DisplayDoorNumSelection(int doorNumSelection)
        {
            Console.WriteLine("Matching Refrigerators:");

            foreach (Appliance appliance in applianceObjects)
            {
                if (appliance is Refrigerator refrigerator && refrigerator.NumOfDoors == doorNumSelection)
                {
                    Console.WriteLine("\n" + refrigerator);
                }
            }
        }

        public static void DisplayBatterVoltageSelection(int batteryVoltageSelection)
        {
            Console.WriteLine("Matching Vacuums:");

            foreach (Appliance appliance in applianceObjects)
            {
                if (appliance is Vacuum vacuum && vacuum.BatteryVoltage == batteryVoltageSelection)
                {
                    Console.WriteLine("\n" + vacuum);
                }
            }
        }

        public static void DiaplaySelectMicrowaves(string microwaveSite)
        {
            Console.WriteLine("Matching Microwaves:");

            foreach (Appliance appliance in applianceObjects)
            {
                if (appliance is Microwave microwave && microwave.RoomType == microwaveSite)
                {
                    Console.WriteLine("\n" + microwave); 
                }
            }
        }

        public static void DisplayDishwasherSelection(string dishwasherSelection)
        {
            //dishwasherSelection;
            Console.WriteLine("Matching Dishwashers:");

            foreach (Appliance appliance in applianceObjects)
            {
                if (appliance is Dishwasher dishwasher && dishwasher.SoundRating == dishwasherSelection)
                {
                    Console.WriteLine("\n\n" + dishwasher);
                }
            }
        }
    }
}
