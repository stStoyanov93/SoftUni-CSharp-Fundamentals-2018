using DungeonsAndCodeWizards.Models.Characters;

using System;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item
    {
        public int Weight { get; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Messages.CHARACTER_IS_DEAD);
            }
        }
    }
}
