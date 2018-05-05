using System;

public class Car
{
    public string Model { get; set; }

    public double FuelAmount { get; set; }

    public double FuelPerKM { get; set; }

    public int DistanceTravelled { get; private set; }

    public void Drive(int distance)
    {
        var fuelNeeded = FuelPerKM * distance;

        if (fuelNeeded > FuelAmount)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            FuelAmount -= fuelNeeded;
            DistanceTravelled += distance;
        }
    }
}

