using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal interface IVehicle
    {
        string VehicleColor { get; set; }
        string VehicleModel { get; set; }
        Guid VehicleVinNumber { get; set; }
        DateTime VehicleProductionDate { get; set; }
    }
}
