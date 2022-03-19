using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    public abstract class Vehicle : IVehicle
    {
        public string VehicleColor { get; set; }
        public string VehicleModel { get; set; }
        public Guid VehicleVinNumber { get; set; }
        public DateTime VehicleProductionDate { get; set; }

        public Vehicle(string vehicleColor, string vehicleModel)
        {
            VehicleColor = vehicleColor;
            VehicleModel = vehicleModel;
            VehicleVinNumber = Guid.NewGuid();
            VehicleProductionDate = DateTime.Now;
        }

        public abstract string PrintVehicleInfo();
    }

    
}
