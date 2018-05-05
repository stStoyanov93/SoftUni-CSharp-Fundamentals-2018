using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class StartUp
    {
        static void Main(string[] args)
        {           
            var amountOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < amountOfCars; i++)
            {
                var inputParams = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = inputParams[0];
                var engine = new Engine(int.Parse(inputParams[1]), int.Parse(inputParams[2]));
                var cargo = new Cargo(int.Parse(inputParams[3]), inputParams[4]);
                var tires = CreateTires(inputParams);

                cars.Add(new Car(model, engine, cargo, tires));
            }

            var command = Console.ReadLine();

            if (command.Equals("fragile"))
            {
                cars = cars.Where(c => c.Cargo.CargoType.Equals(command))
                    .Where(t => t.Tires.Any(ti => ti.Pressure < 1))
                    .ToList();                  
            }
            else if (command.Equals("flamable"))
            {
                cars = cars.Where(c => c.Cargo.CargoType.Equals(command))
                    .Where(e => e.Engine.EnginePower > 250)
                    .ToList();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static List<Tire> CreateTires(string[] inputParams)
        {
            var tireOne = new Tire(double.Parse(inputParams[5]), int.Parse(inputParams[6]));
            var tireTwo = new Tire(double.Parse(inputParams[7]), int.Parse(inputParams[8]));
            var tireThree = new Tire(double.Parse(inputParams[9]), int.Parse(inputParams[10]));
            var tireFour = new Tire(double.Parse(inputParams[11]), int.Parse(inputParams[12]));

            return new List<Tire> { tireOne, tireTwo, tireThree, tireFour};
        }             
    }
}
