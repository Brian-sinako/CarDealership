using System;

namespace CarDealership
{
    class Program
    {
        static void Main(string[] args)
        {
            Dealership dealership = new Dealership();

            // Initial Cars in Dealership
            dealership.AddCar(new Car("Mercedes", "GT63", 2023, "256266", 5500000m));
            dealership.AddCar(new Car("Mercedes", "G Wagon", 2022, "664565", 1000000m));
            dealership.AddCar(new Car("Mercedes", "C63", 2024, "155108", 2699999m));
            dealership.AddCar(new Car("Mercedes", "V Class", 2023, "373555", 2500000m));

            while (true)
            {
                Console.WriteLine("\nWelcome to Mercedes Dealership!");
                Console.WriteLine("Car Dealership Menu:");
                Console.WriteLine("1. Add a Car");
                Console.WriteLine("2. View Total Cars in Inventory");
                Console.WriteLine("3. View Cars We Offer");
                Console.WriteLine("4. Search for a Car by VIN");
                Console.WriteLine("5. Sell a Car");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        try
                        {
                            Console.Write("Enter Make: ");
                            string make = Console.ReadLine();

                            Console.Write("Enter Model: ");
                            string model = Console.ReadLine();

                            Console.Write("Enter Year: ");
                            int year = int.Parse(Console.ReadLine());

                            Console.Write("Enter VIN: ");
                            string vin = Console.ReadLine();

                            Console.Write("Enter Price: ");
                            decimal price = decimal.Parse(Console.ReadLine());

                            dealership.AddCar(new Car(make, model, year, vin, price));
                            Console.WriteLine("Car added successfully!");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format. Please try again.");
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.WriteLine($"Total Cars in Inventory: {Dealership.TotalCars}");
                        break;

                    case "3":
                        dealership.DisplayInventory();
                        break;

                    case "4":
                        Console.Write("Enter VIN of the car to search: ");
                        string vinToSearch = Console.ReadLine();
                        Car foundCar = dealership.SearchCarByVIN(vinToSearch);
                        if (foundCar != null)
                        {
                            foundCar.DisplayDetails();
                        }
                        else
                        {
                            Console.WriteLine("Car not found.");
                        }
                        break;

                    case "5":
                        Console.Write("Enter VIN of the car to sell: ");
                        string vinToSell = Console.ReadLine();
                        try
                        {
                            dealership.SellCar(vinToSell);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"InvalidOperationException: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
