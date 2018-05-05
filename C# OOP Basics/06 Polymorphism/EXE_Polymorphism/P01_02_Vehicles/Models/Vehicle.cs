using System;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumptionPerKm;
    private double tankCapacity;

    protected Vehicle(double fuelQuantity, double litersFuelConsumptionPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
        this.FuelConsumptionPerKm = litersFuelConsumptionPerKm;
        this.TankCapacity = tankCapacity;
    }

    public double TankCapacity
    {
        get { return this.tankCapacity; }
        set { this.tankCapacity = value; }
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public virtual double FuelConsumptionPerKm
    {
        get { return this.fuelConsumptionPerKm; }
        set { this.fuelConsumptionPerKm = value; }
    }

    public virtual string Drive(double distance)
    {
        double neededFuel = distance * this.FuelConsumptionPerKm;

        if (neededFuel < this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        if (liters > this.TankCapacity - this.FuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
        }

        this.FuelQuantity += liters;
    }

    public virtual string DriveEmpty(double distance)
    {
        return null;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}