using System;

namespace CarDealership
{

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public decimal Price { get; set; }

        public Car(string make, string model, int year, string vin, decimal price)
        {
            Make = make;
            Model = model;
            Year = year;
            VIN = vin;
            Price = price;
        }


        public void Deconstruct(out string make, out string model, out int year, out string vin, out decimal price)
        {
            make = Make;
            model = Model;
            year = Year;
            vin = VIN;
            price = Price;
        }
    }
}


