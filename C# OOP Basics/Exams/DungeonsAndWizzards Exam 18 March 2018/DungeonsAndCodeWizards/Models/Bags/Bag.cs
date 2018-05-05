using DungeonsAndCodeWizards.Models.Items;

using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private const int DEFAULT_CAPACITY = 100;

        private readonly List<Item> items;
        private int capacity;

        public Bag(int capacity = DEFAULT_CAPACITY)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        public int Load => this.items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(Messages.BAG_IS_FULL);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(Messages.BAG_IS_EMPTY);
            }

            var itemExists = this.Items.Any(i => i.GetType().Name == name);

            if (!itemExists)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            var item = this.items.FirstOrDefault(i => i.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}
