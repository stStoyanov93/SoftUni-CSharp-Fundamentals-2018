using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public class Engine
    {
        private readonly DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || dungeonMaster.IsGameOver())
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(dungeonMaster.GetStats());
                    break;
                }

                var inputArgs = input.Split();

                var commandName = inputArgs[0];
                var commandArgs = inputArgs.Skip(1).ToArray();

                try
                {
                    switch (commandName)
                    {
                        case "JoinParty":
                            Console.WriteLine(dungeonMaster.JoinParty(commandArgs));
                            break;                     
                        case "AddItemToPool":
                            Console.WriteLine(dungeonMaster.AddItemToPool(commandArgs));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(dungeonMaster.PickUpItem(commandArgs));
                            break;
                        case "UseItem":
                            Console.WriteLine(dungeonMaster.UseItem(commandArgs));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(dungeonMaster.UseItemOn(commandArgs));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(commandArgs));
                            break;
                        case "GetStats":
                            Console.WriteLine(dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(dungeonMaster.Attack(commandArgs));
                            break;
                        case "Heal":
                            Console.WriteLine(dungeonMaster.Heal(commandArgs));
                            break;
                        case "EndTurn":
                            Console.WriteLine(dungeonMaster.EndTurn(commandArgs));
                            break;
                        case "IsGameOver":
                            Console.WriteLine(dungeonMaster.IsGameOver());
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"Parameter Error: {e.Message}");
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine($"Invalid Operation: {e.Message}");
                }
            }
        }
    }
}
