using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private readonly List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public IReadOnlyCollection<Product> Trunk
        {
            get
            {
                return this.trunk.AsReadOnly();
            }
        }

        public bool IsFull => this.trunk.Sum(x => x.Weight) >= this.Capacity;

        public bool IsEmpty => !this.trunk.Any();

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var item = this.trunk.Last();

            this.trunk.RemoveAt(this.trunk.Count - 1);

            return item;
        }
    }
}
