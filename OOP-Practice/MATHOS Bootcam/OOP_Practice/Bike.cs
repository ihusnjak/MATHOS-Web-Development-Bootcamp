using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public class Bike : Vehicle
    {
        public Bike(string bikeType, string bikePower, string vehicleColor, string vehicleModel) 
            : base(vehicleColor, vehicleModel)
        {
            BikeType = bikeType;
            BikePower = bikePower;
        }

        public string BikeType { get; set; }
        public string BikePower { get; set; }

        public override string PrintVehicleInfo()
        {
            return "\n----------" + this.VehicleModel + "\n" + this.VehicleColor + "\n"
                + this.VehicleProductionDate + "\n" + this.VehicleVinNumber
                + "\n" + this.BikeType + "\n" + this.BikePower + "\n----------";
        }
    }
}
