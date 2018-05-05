using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Items;

using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealt;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints ;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealt = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Messages.NAME_IS_NULL_OR_EMPTY);
                }

                this.name = value;
            }
        }

        public double BaseHealt
        {
            get { return this.baseHealt; }
            private set { this.baseHealt = value; }
        }

        public double Health
        {
            get { return this.health; }
            set { this.health = Math.Min(value, this.baseHealt); }
        }

        public double BaseArmor
        {
            get { return this.baseArmor; }
            private set { this.baseArmor = value; }
        }

        public double Armor
        {
            get { return this.armor; }
            set { this.armor = Math.Min(value, this.BaseArmor); }
        }

        public double AbilityPoints
        {
            get { return this.abilityPoints; }
            private set { this.abilityPoints = value; }
        }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public bool IsAlive { get; set; }

        protected virtual double RestHealMultiplier => 0.2;

        public void IsCharacterAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(Messages.CHARACTER_IS_DEAD);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.IsCharacterAlive();

            if (hitPoints <= this.Armor)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                var hitpointAfterArmor = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= hitpointAfterArmor;

                if (this.Health <= 0)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            this.IsCharacterAlive();

            this.Health += this.BaseHealt * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.IsCharacterAlive();
            character.IsCharacterAlive();
            
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.IsCharacterAlive();
            character.IsCharacterAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.IsCharacterAlive();

            this.Bag.AddItem(item);
        }
    }
}
