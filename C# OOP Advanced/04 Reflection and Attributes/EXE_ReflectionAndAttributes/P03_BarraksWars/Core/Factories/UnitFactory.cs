namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var model = assembly.GetTypes()
                .FirstOrDefault(m => m.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Invalid unit type!");
            }

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is not a unit type!");
            }

            var unit = (IUnit)Activator.CreateInstance(model);
            return unit;
        }
    }
}
