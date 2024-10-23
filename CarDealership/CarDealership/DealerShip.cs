using System;
using System.Collections.Generic;

namespace CarDealership
{
    public class Dealership
    {
        private static List<Car> inventory = new List<Car>();
        public static int TotalCars => inventory.Count;

        public void AddCar(Car car)
        {
            if (string.IsNullOrEmpty(car.VIN))
                throw new ArgumentNullException(nameof(car.VIN), "VIN cannot be null or empty.");

            if (inventory.Exists(c => c.VIN == car.VIN))
                throw new InvalidOperationException("A car with the same VIN already exists.");

            inventory.Add(car);
        }

        public void SellCar(string vin)
        {
            Car carToSell = SearchCarByVIN(vin);
            if (carToSell == null)
                throw new InvalidOperationException("Car not found.");

            inventory.Remove(carToSell);
            Console.WriteLine($"Car with VIN {vin} has been sold.");
        }

        public void DisplayInventory()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("No cars in inventory.");
                return;
            }

            foreach (var car in inventory)
            {
                car.DisplayDetails();
            }
        }

        public Car SearchCarByVIN(string vin)
        {
            return inventory.Find(c => c.VIN == vin);
        }
    }
}
