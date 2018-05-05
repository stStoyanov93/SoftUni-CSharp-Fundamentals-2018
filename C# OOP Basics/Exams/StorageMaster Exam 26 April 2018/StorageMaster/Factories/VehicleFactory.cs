using StorageMaster.Models.Vehicles;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            var typeOfVehicle = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (typeOfVehicle == null)
            {
                throw new InvalidOperationException($"Invalid vehicle type!");
            }

            var vehicle = (Vehicle)Activator.CreateInstance(typeOfVehicle);
            return vehicle;
        }
    }
}
