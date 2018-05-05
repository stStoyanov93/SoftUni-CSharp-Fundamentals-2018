using System;

namespace P01_Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //P01
            //var carInputParams = Console.ReadLine()
            //     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // var carFuelQuantity = double.Parse(carInputParams[1]);
            // var carFuelConsumption = double.Parse(carInputParams[2]);

            // var car = new Car(carFuelQuantity, carFuelConsumption);

            // var truckInputParams = Console.ReadLine()
            //     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            // var truckFuelQuantity = double.Parse(truckInputParams[1]);
            // var truckFuelConsumption = double.Parse(truckInputParams[2]);

            // var truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            // var numberOfCommands = int.Parse(Console.ReadLine());

            // for (int i = 0; i < numberOfCommands; i++)
            // {
            //     var inputParams = Console.ReadLine()
            //         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //     var command = inputParams[0];
            //     var vehicleType = inputParams[1];
            //     var distanceOrFuel = double.Parse(inputParams[2]);

            //     IVehicle vehicle = null;

            //     if (vehicleType == "Car")
            //     {
            //         vehicle = car;
            //     }
            //     else if (vehicleType == "Truck")
            //     {
            //         vehicle = truck;
            //     }

            //     if (vehicle != null)
            //     {
            //         if (command == "Drive")
            //         {
            //             Console.WriteLine(vehicle.Drive(distanceOrFuel));
            //         }
            //         else if (command == "Refuel")
            //         {
            //             vehicle.Refuel(distanceOrFuel);
            //         }
            //     }
            // }

            // Console.WriteLine(car);
            // Console.WriteLine(truck);

            //P02
            //one test not passing?
            var carInputParams = Console.ReadLine().Split();
            var fuelQuantity = double.Parse(carInputParams[1]);
            var fuelConsumptionPerKm = double.Parse(carInputParams[2]);
            var tankCapacity = double.Parse(carInputParams[3]);

            Vehicle car = car = new Car(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

            var truckInputParams = Console.ReadLine().Split();
            fuelQuantity = double.Parse(truckInputParams[1]);
            fuelConsumptionPerKm = double.Parse(truckInputParams[2]);
            tankCapacity = double.Parse(truckInputParams[3]);

            Vehicle truck = truck = new Truck(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

            var busInputParams = Console.ReadLine().Split();
            fuelQuantity = double.Parse(busInputParams[1]);
            fuelConsumptionPerKm = double.Parse(busInputParams[2]);
            tankCapacity = double.Parse(busInputParams[3]);

            Vehicle bus = bus = new Bus(fuelQuantity, fuelConsumptionPerKm, tankCapacity);

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var inputParams = Console.ReadLine().Split();
                var command = inputParams[0];
                var vehicleType = inputParams[1];

                if (vehicleType == "Car")
                {
                    ExecuteCommand(car, command, double.Parse(inputParams[2]));
                }
                else if (vehicleType == "Truck")
                {
                    ExecuteCommand(truck, command, double.Parse(inputParams[2]));
                }
                else if (vehicleType == "Bus")
                {
                    ExecuteCommand(bus, command, double.Parse(inputParams[2]));
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double parameter)
        {
            switch (command)
            {
                case "DriveEmpty":
                    Bus bus = (Bus)vehicle;
                    Console.WriteLine(bus.DriveEmpty(parameter));
                    break;
                case "Drive":
                    Console.WriteLine(vehicle.Drive(parameter));
                    break;
                case "Refuel":
                    try
                    {
                        vehicle.Refuel(parameter);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
            }
        }
    }
}
