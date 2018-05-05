using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using StorageMaster.Models.Storages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace StorageMaster
{
    public class StorageMaster
    {
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;

        private IList<Product> productPool;
        private IList<Storage> storageRegister;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
            this.vehicleFactory = new VehicleFactory();
            this.productPool = new List<Product>();
            this.storageRegister = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);
            this.productPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegister.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegister.Where(s => s.Name == storageName).First();
            this.currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var productCount = productNames.Count();
            var loadedProducts = 0;

            foreach (var item in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.productPool.Any(p => p.GetType().Name == item))
                {
                    throw new InvalidOperationException($"{item} is out of stock!");
                }

                var lastItem = this.productPool.Where(p => p.GetType().Name == item).Last();
                this.productPool.Remove(lastItem);

                this.currentVehicle.LoadProduct(lastItem);
                loadedProducts++;
            }

            return $"Loaded {loadedProducts}/{productCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegister.Any(s => s.Name == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegister.Any(s => s.Name == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var sourceStorage = this.storageRegister.First(s => s.Name == sourceName);
            var destinationStorage = this.storageRegister.First(s => s.Name == destinationName);

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var sourceStorage = this.storageRegister.First(s => s.Name == storageName);
            var vehicle = sourceStorage.GetVehicle(garageSlot);
            var productsInVehicle = vehicle.Trunk.Count;

            var unloadedProducts = sourceStorage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProducts}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var sourceStorage = this.storageRegister.First(s => s.Name == storageName);

            var dictionary = new Dictionary<string, int>();

            foreach (var item in sourceStorage.Products)
            {
                if (!dictionary.ContainsKey(item.GetType().Name))
                {
                    dictionary[item.GetType().Name] = 0;
                }

                dictionary[item.GetType().Name]++;
            }

            var orderedDictionary = dictionary.OrderByDescending(i => i.Value).ThenBy(i => i.Key);

            var builder = new StringBuilder();
            var weight = sourceStorage.Products.Sum(x => x.Weight);

            builder.Append($"Stock ({weight}/{sourceStorage.Capacity}): [");

            foreach (var item in orderedDictionary)
            {
                builder.Append($"{item.Key} ({item.Value}), ");
            }

            if (builder.ToString()[builder.Length - 2] != ',')
            {
                builder.Append("]");
                builder.AppendLine();
            }
            else
            {
                builder.Replace(", ", "]", builder.Length - 2, 2);
                builder.AppendLine();
            }
            

            builder.Append("Garage: [");

            var sr = sourceStorage.Garage.ToArray();

            for (int i = 0; i < sr.Length; i++)
            {
                
                if (sr[i] == null)
                {
                    builder.Append("empty|");
                }
                else
                {
                    builder.Append($"{sr[i].GetType().Name}|");
                }
            }

            if (builder.ToString()[builder.Length - 1] == '[')
            {
                builder.Append("]");
            }
            else
            {
                builder.Replace('|', ']', builder.Length - 1, 1);
            }
                
            return builder.ToString();
        }

        public string GetSummary()
        {
            var orderedStorages = this.storageRegister.OrderByDescending(s => s.Products.Sum(p => p.Price));
            var builder = new StringBuilder();

            foreach (var s in orderedStorages)
            {
                builder.AppendLine($"{s.Name}:");
                builder.AppendLine($"Storage worth: ${s.Products.Sum(p => p.Price):F2}");
            }

            return builder.ToString().Trim();
        }

    }
}
