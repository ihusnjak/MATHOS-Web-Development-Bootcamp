using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public class Car : Vehicle
    {
        public Car(string carEngine, string carNumOfSeats, string vehicleColor, string vehicleModel) 
            : base(vehicleColor, vehicleModel)
        {
            CarEngine = carEngine;
            CarNumOfSeats = carNumOfSeats;
        }

        public string CarEngine { get; set; }
        public string CarNumOfSeats { get; set; }

        public override string PrintVehicleInfo()
        {
            return "\n----------" + this.VehicleModel + "\n" + this.VehicleColor + "\n"
                + this.VehicleProductionDate + "\n" + this.VehicleVinNumber
                + "\n" + this.CarEngine + "\n" + this.CarNumOfSeats + "\n----------";
        }
    }
}
