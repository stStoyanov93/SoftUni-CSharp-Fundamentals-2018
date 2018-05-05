public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double litersFuelConsumptionPerKm, double tankCapacity)
        : base(fuelQuantity, litersFuelConsumptionPerKm, tankCapacity) { }

    public override string DriveEmpty(double distance)
    {
        return base.Drive(distance);
    }

    public override string Drive(double distance)
    {
        double neededFuel = distance * (this.FuelConsumptionPerKm + 1.4);

        if (neededFuel < this.FuelQuantity)
        {
            this.FuelQuantity -= neededFuel;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        return $"{this.GetType().Name} needs refueling";
    }
}