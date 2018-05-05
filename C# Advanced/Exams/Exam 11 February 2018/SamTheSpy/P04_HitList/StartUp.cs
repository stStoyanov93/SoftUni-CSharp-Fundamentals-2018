using System;
using System.Collections.Generic;
using System.Linq;

namespace T04
{
    class StartUp
    {
        static void Main(string[] args)
        {
            checked
            {
                var targetInfoIndex = long.Parse(Console.ReadLine());
                var people = new Dictionary<string, Dictionary<string, string>>();
                string input;

                while ((input = Console.ReadLine()) != "end transmissions")
                {
                    var inputTokens = input.Split(new[] { "=", ";", ":" }, StringSplitOptions.RemoveEmptyEntries);
                    var name = inputTokens[0];

                    if (!people.ContainsKey(name))
                    {
                        people[name] = new Dictionary<string, string>();
                    }

                    for (int i = 1; i < inputTokens.Length; i += 2)
                    {
                        var key = inputTokens[i];
                        var value = inputTokens[i + 1];

                        people[name][key] = value;
                    }
                }

                var order = Console.ReadLine().Split();
                var target = order[1];
                var targetinfo = people[target].ToList().OrderBy(a => a.Key);
                var sum = 0L;

                Console.WriteLine($"Info on {target}:");

                foreach (var item in targetinfo)
                {
                    Console.WriteLine($"---{item.Key}: {item.Value}");
                    sum += item.Key.Length + item.Value.Length;
                }

                Console.WriteLine($"Info index: {sum}");

                if (sum >= targetInfoIndex)
                {
                    Console.WriteLine("Proceed");
                }
                else
                {
                    Console.WriteLine($"Need {targetInfoIndex - sum} more info.");
                }
            }
        }
    }
}