using OOP2_Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAssignment1
{
    public class Vacuum : Appliance
    {
        public string Grade { get; set; }
        public int BatteryVoltage { get; set; }

        public Vacuum(int itemNumber, string brand, int quantity, int wattage, string color, double price, string grade, int batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
            Grade = grade;
            BatteryVoltage = batteryVoltage;
        }

        public override string ToString()
        {
            string obj = ($"ItemNumber: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}" +
                $"\nGrade: {Grade}\nBattery Voltage: {BatteryVoltage} \n");
            return obj;
        }
    }
}
