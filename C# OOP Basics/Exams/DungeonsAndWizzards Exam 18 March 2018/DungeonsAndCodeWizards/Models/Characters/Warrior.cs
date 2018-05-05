using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Characters.Enums;

using System;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            :base(name, 100, 50, 40, new Satchel(), faction) { }

        public void Attack(Character character)
        {
            this.IsCharacterAlive();
            character.IsCharacterAlive();

            if (this == character)
            {
                throw new InvalidOperationException(Messages.SELF_HARM_ATTEMP);
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
