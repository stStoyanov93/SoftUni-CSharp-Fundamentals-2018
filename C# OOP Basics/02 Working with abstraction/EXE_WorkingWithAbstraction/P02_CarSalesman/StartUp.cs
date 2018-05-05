using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {           
            var engines = new HashSet<Engine>();
            var enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                AddEngines(engines);
            }

            var cars = new HashSet<Car>();
            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                AddCars(cars, engines);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void AddEngines(HashSet<Engine> engines)
        {
            var inputParams = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = inputParams[0];
            var power = int.Parse(inputParams[1]);

            var engine = new Engine(model, power);

            if (inputParams.Length > 2)
            {
                if (!int.TryParse(inputParams[2], out int displcement))
                {
                    engine.Efficiency = inputParams[2];
                }
                else
                {
                    engine.Displacement = displcement.ToString();
                }
            }

            if (inputParams.Length > 3)
            {
                string efficiency = inputParams[3];
                engine.Efficiency = efficiency;
            }

            engines.Add(engine);
        }

        private static void AddCars(HashSet<Car> cars, HashSet<Engine> engines)
        {
            var inputParams = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = inputParams[0];
            var engineType = inputParams[1];

            var car = new Car(model, engines.FirstOrDefault(e => e.Model == engineType));

            if (inputParams.Length > 2)
            {
                if (!int.TryParse(inputParams[2], out int weight))
                {
                    car.Color = inputParams[2];
                }
                else
                {
                    car.Weight = weight.ToString();
                }
            }
            if (inputParams.Length > 3)
            {
                car.Color = inputParams[3];
            }

            cars.Add(car);
        }
    }
}
