using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var cars = new Dictionary<string, Car>();
        string[] inputParams = null;

        for (int i = 0; i < n; i++)
        {
            inputParams = Console.ReadLine().Split();

            var model = inputParams[0];
            var fuelAmount = double.Parse(inputParams[1]);
            var fuelConsumption = double.Parse(inputParams[2]);

            var car = new Car()
            {
                Model = model,
                FuelAmount = fuelAmount,
                FuelPerKM = fuelConsumption
            };

            cars.Add(model, car);
        }

        string input = null;

        while ((input = Console.ReadLine()) != "End")
        {
            inputParams = input.Split();
            var model = inputParams[1];
            var distance = int.Parse(inputParams[2]);

            cars[model].Drive(distance);
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Key} {car.Value.FuelAmount:F2} {car.Value.DistanceTravelled}");
        }
    }
}

