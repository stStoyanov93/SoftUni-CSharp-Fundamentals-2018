using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            var commands = new List<string>();

            string input;

            while ((input = Console.ReadLine()) != "Print")
            {
                var inputParams = input
                    .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                var command = inputParams[0];
                var condition = inputParams[1];
                var conditionArgument = inputParams[2];

                if (command == "Add filter")
                {
                    commands.Add(condition + " " + conditionArgument);
                }
                else if (command == "Remove filter")
                {
                    commands.Remove(condition + " " + conditionArgument);
                }

            }

            people = FilterNames(people, commands);

            if (people.Count != 0)
            {
                Console.WriteLine(string.Join(" ", people));
            }
        }

        static List<string> FilterNames(List<string> people, List<string> commands)
        {
            foreach (string command in commands)
            {
                var commandParams = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var order = commandParams[0];

                switch (order)
                {
                    case "Starts":
                        people = people.Where(name => !name.StartsWith(commandParams[2])).ToList();
                        break;
                    case "Ends":
                        people = people.Where(name => !name.EndsWith(commandParams[2])).ToList();
                        break;
                    case "Length":
                        people = people.Where(name => name.Length != int.Parse(commandParams[1])).ToList();
                        break;
                    case "Contains":
                        people = people.Where(name => !name.Contains(commandParams[1])).ToList();
                        break;
                }
            }

            return people;
        }
    }
}
