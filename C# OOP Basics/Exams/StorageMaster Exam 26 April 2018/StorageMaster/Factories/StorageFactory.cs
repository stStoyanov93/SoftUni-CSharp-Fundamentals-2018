using StorageMaster.Models.Storages;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            var typeOfStorage = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (typeOfStorage == null)
            {
                throw new InvalidOperationException($"Invalid storage type!");
            }

            var storage = (Storage)Activator.CreateInstance(typeOfStorage, name);
            return storage;
        }
    }
}
