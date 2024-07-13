using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment1
{
    public class Refrigerator : Appliance
    {
        public int NumOfDoors { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Refrigerator(int itemNumber, string brand, int quantity, int wattage, string color, double price, int numOfDoors,
            int height, int width) : base(itemNumber, brand, quantity, wattage, color, price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
            NumOfDoors = numOfDoors;
            Height = height;
            Width = width;

        }

        public override string ToString()
        {
            string obj = ($"ItemNumber: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}" +
                $"\nNumber of Doors: {NumOfDoors}\nHeight: {Height}\nWidth: {Width}\n");
            return obj;
        }
    }
}
