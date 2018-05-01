namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.Contracts;
    using Travel.Entities.Airplanes.Contracts;

    public abstract class Airplane : IAirplane
    {
        private readonly List<IBag> bags;
        private readonly List<IPassenger> passenger;

        protected Airplane(int seats, int bags)
        {           
            this.Seats = seats;
            this.BaggageCompartments = bags;

            this.passenger = new List<IPassenger>();
            this.bags = new List<IBag>();
        }

        public int Seats { get; }

        public int BaggageCompartments { get; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.bags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => this.passenger.AsReadOnly();

        public bool IsOverbooked => this.passenger.Count > this.Seats;

        public void AddPassenger(IPassenger passenger)
        {
            this.passenger.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passanger = this.passenger[seat];

            this.passenger.RemoveAt(seat);           

            return passanger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.bags
                .Where(b => b.Owner == passenger)
                .ToArray();

            foreach (var bag in passengerBags)
            {
                this.bags.Remove(bag);
            }
                
            return passengerBags;
        }

        public void LoadBag(IBag bag)
        {
            //or just >??
            var isBaggageCompartmentFull = this.bags.Count >= this.BaggageCompartments;

            if (isBaggageCompartmentFull)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }               

            this.bags.Add(bag);
        }
    }
}