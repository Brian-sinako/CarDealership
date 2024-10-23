using System;

namespace CarDealership
{
    // Showing CARS method
    public static class CarExtensions
    {
        public static void DisplayDetails(this Car car)
        {
            Console.WriteLine($"Make: {car.Make}, Model: {car.Model}, Year: {car.Year}, VIN: {car.VIN}, Price: {car.Price:C}");
        }
    }
}

