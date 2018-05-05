using System;
using System.Collections.Generic;
using System.Linq;


public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        string[] inputParams = null;
        var cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            inputParams = Console.ReadLine().Split();

            var model = inputParams[0];

            var engineSpeed = int.Parse(inputParams[1]);
            var enginePower = int.Parse(inputParams[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var weight = int.Parse(inputParams[3]);
            var type = inputParams[4];
            var cargo = new Cargo(weight, type);

            var pressure1 = double.Parse(inputParams[5]);
            var age1 = int.Parse(inputParams[6]);
            var tire1 = new Tire(age1, pressure1);

            var pressure2 = double.Parse(inputParams[7]);
            var age2 = int.Parse(inputParams[8]);
            var tire2 = new Tire(age2, pressure2);

            var pressure3 = double.Parse(inputParams[9]);
            var age3 = int.Parse(inputParams[10]);
            var tire3 = new Tire(age1, pressure1);

            var pressure4 = double.Parse(inputParams[11]);
            var age4 = int.Parse(inputParams[12]);
            var tire4 = new Tire(age1, pressure1);

            var tires = new Tire[] { tire1, tire2, tire3, tire4 };
            cars.Add(new Car(model, engine, cargo, tires));
        }

        var command = Console.ReadLine();

        if (command == "fragile")
        {
            var carsWithFragileCargo = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1));

            foreach (var item in carsWithFragileCargo)
            {
                Console.WriteLine($"{item.Model}");
            }
        }
        else
        {
            var carsWithFlamableCargo = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250);

            foreach (var item in carsWithFlamableCargo)
            {
                Console.WriteLine($"{item.Model}");
            }
        }
    }
}

