namespace Travel.Entities
{
	using System.Collections.Generic;
	using System.Linq;

	using Contracts;
	using Items.Contracts;

	public class Bag : IBag
	{
		private readonly List<IItem> items;
        private IPassenger owner;

		public Bag(IPassenger owner, IEnumerable<IItem> items)
		{
            this.owner = owner;
			this.items = items.ToList();
		}

        public IPassenger Owner => this.owner;

		public IReadOnlyCollection<IItem> Items => this.items.AsReadOnly();
	}
}