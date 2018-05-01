namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            var typeOfAirplane = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            //if (typeOfAirplane == null)
            //{
            //    throw new InvalidOperationException($"Invalid airplane type!");
            //}

            var airplane = (IAirplane)Activator.CreateInstance(typeOfAirplane);
            return airplane;
        }
	}
}