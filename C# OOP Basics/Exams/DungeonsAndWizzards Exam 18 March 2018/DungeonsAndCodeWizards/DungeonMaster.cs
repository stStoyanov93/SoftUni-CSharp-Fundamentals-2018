using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private IList<Character> party;
        private IList<Item> itemPool;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private int lastSurvivorRound = 0;

        public DungeonMaster()
        {
            this.party = new List<Character>();
            this.itemPool = new List<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var factionAsString = args[0];
            var charType = args[1];
            var name = args[2];

            var character = this.characterFactory.CreateCharacter(factionAsString, charType, name);
            this.party.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];

            var item = this.itemFactory.CreateItem(itemName);
            this.itemPool.Add(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];

            var character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.itemPool.Last();
            character.ReceiveItem(item);
            this.itemPool.RemoveAt(this.itemPool.Count - 1);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.party.FirstOrDefault(c => c.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            giver.UseItemOn(giver.Bag.Items.FirstOrDefault(i => i.GetType().Name == itemName), receiver);

            return $"{giverName} used {itemName} on {receiverName}.";

        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = this.party.FirstOrDefault(c => c.Name == giverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            receiver.ReceiveItem(giver.Bag.Items.FirstOrDefault(i => i.GetType().Name == itemName));

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var builder = new StringBuilder();
            var sortedParty = this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health);

            foreach (var ch in sortedParty)
            {
                var status = ch.IsAlive ? "Alive" : "Dead";
                builder.AppendLine($"{ch.Name} - HP: {ch.Health}/{ch.BaseHealt}, AP: {ch.Armor}/{ch.BaseArmor}, Status: {status}");
            }

            return builder.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = this.party.FirstOrDefault(c => c.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (attacker.GetType() != typeof(Warrior))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            var attackerChar = (Warrior)attacker;
            attackerChar.Attack(receiver);

            var builder = new StringBuilder();

            builder.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");
            builder.AppendLine($"{receiverName} has {receiver.Health}/{receiver.BaseHealt} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                builder.AppendLine($"{receiver.Name} is dead!");
            }

            return builder.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var receiverName = args[1];

            var healer = this.party.FirstOrDefault(c => c.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (healer.GetType() != typeof(Cleric))
            {
                throw new ArgumentException($"{healer.Name} cannot heal!");
            }

            var cleric = (Cleric)healer;
            cleric.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var aliveMembers = this.party.Where(c => c.IsAlive).ToArray();

            if (aliveMembers.Length <= 1)
            {
                this.lastSurvivorRound++;
            }

            var builder = new StringBuilder();

            foreach (var m in aliveMembers)
            {
                var healthBeforeRest = m.Health;
                m.Rest();

                builder.AppendLine($"{m.Name} rests ({healthBeforeRest} => {m.Health})");
            }

            return builder.ToString().Trim();
        }

        public bool IsGameOver()
        {
            return this.lastSurvivorRound > 1;
        }

    }
}
