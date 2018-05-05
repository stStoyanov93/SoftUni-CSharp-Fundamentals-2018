using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Characters.Enums;

using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            :base(name, 50, 25, 40, new Backpack(), faction) { }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.IsCharacterAlive();
            character.IsCharacterAlive();

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException($"Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
