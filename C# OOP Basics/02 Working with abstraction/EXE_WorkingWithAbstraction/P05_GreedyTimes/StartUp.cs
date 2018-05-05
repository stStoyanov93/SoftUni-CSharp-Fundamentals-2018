using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var bag = new Dictionary<string, Dictionary<string, long>>();
            var capacity = long.Parse(Console.ReadLine());

            var items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < items.Length; i += 2)
            {
                var jewelName = items[i];
                var jewelQuantity = long.Parse(items[i + 1]);

                var jewelsType = GetJewelsType(jewelName);

                if (jewelsType == string.Empty
                    || capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + jewelQuantity)
                {
                    continue;
                }

                switch (jewelsType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(jewelsType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (jewelQuantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }                                
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[jewelsType].Values.Sum() + jewelQuantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(jewelsType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (jewelQuantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[jewelsType].Values.Sum() + jewelQuantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(jewelsType))
                {
                    bag[jewelsType] = new Dictionary<string, long>();
                }

                if (!bag[jewelsType].ContainsKey(jewelName))
                {
                    bag[jewelsType][jewelName] = 0;
                }

                bag[jewelsType][jewelName] += jewelQuantity;
            }

            foreach (var typeOfJewel in bag)
            {
                Console.WriteLine($"<{typeOfJewel.Key}> ${typeOfJewel.Value.Values.Sum()}");

                foreach (var item in typeOfJewel.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static string GetJewelsType(string itemName)
        {
            var jewelsType = string.Empty;

            if (itemName.Length == 3)
            {
                jewelsType = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                jewelsType = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                jewelsType = "Gold";
            }

            return jewelsType;
        }
    }
}
