using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Vehicle> list = new List<Vehicle>();
            Console.WriteLine("CREATE VEHCLES APP");
            string exitString = "0";
            do
            {
                Console.WriteLine("Enter choice: B for bike or C for car");
                string choice = Console.ReadLine();
                Vehicle vehicle = CreateVehicle(choice);
                list.Add(vehicle);
                Console.WriteLine("Enter continue or press 0 to exit");
                exitString = Console.ReadLine();
            } while (exitString != "0");


            foreach(Vehicle vehicle in list)
            {
                Console.WriteLine(vehicle.PrintVehicleInfo());
            }

            Console.ReadLine();
            
            

        }

        private static Vehicle CreateVehicle(string choice)
        {
            switch (choice)
            {
                case "B":
                case "b":
                    Console.WriteLine("Enter bike type");
                    string type = Console.ReadLine();
                    Console.WriteLine("Enter bike power");
                    string power = Console.ReadLine();
                    Console.WriteLine("Enter bike color");
                    string color = Console.ReadLine();
                    Console.WriteLine("Enter bike model");
                    string model = Console.ReadLine();
                    return new Bike(type, power, color, model);
                case "C":
                case "c":
                    Console.WriteLine("Enter car engine");
                    string engine = Console.ReadLine();
                    Console.WriteLine("Enter number of seats");
                    string seats = Console.ReadLine();
                    Console.WriteLine("Enter car color");
                    color = Console.ReadLine();
                    Console.WriteLine("Enter car model");
                    model = Console.ReadLine();
                    return new Car(engine, seats, color, model);
                default:
                    throw new Exception("Invalid input");

            }
        }
    }
}
