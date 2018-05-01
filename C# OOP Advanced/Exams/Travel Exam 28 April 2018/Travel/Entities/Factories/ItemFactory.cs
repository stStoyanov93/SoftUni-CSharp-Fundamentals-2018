namespace Travel.Entities.Factories
{
	using Contracts;
	using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            var typeOfItem = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            //if (typeOfItem == null)
            //{
            //    throw new InvalidOperationException($"Invalid item type!");
            //}

            var item = (IItem)Activator.CreateInstance(typeOfItem);
            return item;
        }
	}
}
