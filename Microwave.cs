using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_Assignment1
{
    public class Microwave : Appliance
    {
        public double Capacity { get; set; }
        public string RoomType { get; set; }

        public Microwave(int itemNumber, string brand, int quantity, int wattage, string color, double price, double capacity, string roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
            Capacity = capacity;
            RoomType = roomType;
        }

        public override string ToString()
        {
            string obj = ($"ItemNumber: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}" +
                $"\nCapacity: {Capacity}\nRoom Type: {RoomType}\n");
            return obj;
        }
    }
}
