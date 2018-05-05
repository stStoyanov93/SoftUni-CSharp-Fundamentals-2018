using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private string name;
        protected readonly Vehicle[] vehicles;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.vehicles = vehicles.ToArray();
            this.products = new List<Product>();
        }

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double SumProducts => this.products.Sum(p => p.Price);

        public IReadOnlyCollection<Vehicle> Garage
        {
            get
            {
                return this.vehicles;
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products.AsReadOnly();
            }
        }


        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots | garageSlot < 0)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            var vehicle = this.vehicles[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);

            for (int i = 0; i < deliveryLocation.GarageSlots; i++)
            {
                if (deliveryLocation.vehicles[i] == null)
                {
                    deliveryLocation.vehicles[i] = vehicle;
                    this.vehicles[garageSlot] = null;
                    return i;
                }
            }

            throw new InvalidOperationException ("No room in garage!");
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = this.GetVehicle(garageSlot);

            var numberOfUnloadedProducts = 0;

            while (!vehicle.IsEmpty)
            {
                var product = vehicle.Unload();
                numberOfUnloadedProducts++;

                this.products.Add(product);

                if (this.IsFull)
                {
                    return numberOfUnloadedProducts;
                }
            }

            return numberOfUnloadedProducts;
        }
    }
}
