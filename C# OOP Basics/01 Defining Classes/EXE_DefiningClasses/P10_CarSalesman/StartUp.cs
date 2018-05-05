using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var engines = new List<Engine>();
        var cars = new List<Car>();

        var numberOfEngine = int.Parse(Console.ReadLine());
        string[] input = null;

        for (int i = 0; i < numberOfEngine; i++)
        {
            input = Console.ReadLine().Split();
            var model = input[0];
            var power = input[1];
            var engine = new Engine(model, power);

            if (input.Length == 4)
            {
                engine.Displacement = input[2];
                engine.Efficiency = input[3];
            }
            else if (input.Length == 3)
            {
                var displacement = 0;

                if (int.TryParse(input[2], out displacement))
                {
                    engine.Displacement = input[2];
                }
                else
                {
                    engine.Efficiency = input[2];
                }
            }

            engines.Add(engine);
        }

        var numberOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCars; i++)
        {
            input = Console.ReadLine().Split();
            var model = input[0];
            var engine = engines.Where(x => x.Model == input[1]).FirstOrDefault();
            var car = new Car(model, engine);

            if (input.Length == 4)
            {
                car.Weight = input[2];
                car.Color = input[3];
            }
            else if (input.Length == 3)
            {
                var weight = 0;

                if (int.TryParse(input[2], out weight))
                {
                    car.Weight = input[2];
                }
                else
                {
                    car.Color = input[2];
                }
            }

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model}:");
            Console.WriteLine($"  {car.Engine.Model}:");
            Console.WriteLine($"    Power: {car.Engine.Power}");
            Console.WriteLine($"    Displacement: {car.Engine.Displacement ?? "n/a"}");
            Console.WriteLine($"    Efficiency: {car.Engine.Efficiency ?? "n/a"}");
            Console.WriteLine($"  Weight: {car.Weight ?? "n/a"}");
            Console.WriteLine($"  Color: {car.Color ?? "n/a"}");
        }
    }
}

