using DungeonsAndCodeWizards.Models.Items;

using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            var typeOfItem = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (typeOfItem == null)
            {
                throw new ArgumentException($"Invalid item \"{type}\"!");
            }

            var item = (Item)Activator.CreateInstance(typeOfItem);
            return item;
        }
    }
}
