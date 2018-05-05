using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Characters.Enums;

using System;
using System.Linq;
using System.Reflection;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            if (!Enum.TryParse<Faction>(faction, out var parsedFaction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            var typeOfCharacter = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (typeOfCharacter == null)
            {
                throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            var character = (Character)Activator.CreateInstance(typeOfCharacter, name, parsedFaction);
            return character;
        }
    }
}
