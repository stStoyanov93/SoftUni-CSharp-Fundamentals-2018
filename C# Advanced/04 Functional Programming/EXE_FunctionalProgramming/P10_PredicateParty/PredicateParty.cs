using System;
using System.Linq;
using System.Collections.Generic;

namespace P10_PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var conditions = new Dictionary<string, Func<string, string, bool>>
            {
                {
                    "StartsWith",
                    (name, substring) => name.StartsWith(substring)
                },
                {
                    "EndsWith",
                    (name, substring) => name.EndsWith(substring)
                },
                {
                    "Length",
                    (name, length) => name.Length.ToString().Equals(length)
                }
            };

            var people = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();                       

            string input;

            while ((input = Console.ReadLine()) != "Party!")
            {
                var inputParams = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = inputParams[0];
                var condition = inputParams[1];
                var conditionArgument = inputParams[2];

                var filteredGuests = new List<string>();

                foreach (var person in people)
                {
                    if (conditions[condition](person, conditionArgument))
                    {
                        switch (command)
                        {
                            case "Double":
                                filteredGuests.Add(person);
                                filteredGuests.Add(person);
                                break;
                            case "Remove":
                                break;
                        }
                    }
                    else
                    {
                        filteredGuests.Add(person);
                    }
                }

                people = filteredGuests;               
            }

            if (people.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
