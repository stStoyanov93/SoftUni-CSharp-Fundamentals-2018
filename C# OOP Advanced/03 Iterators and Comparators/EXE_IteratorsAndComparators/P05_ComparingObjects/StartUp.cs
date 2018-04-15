using System;
using System.Collections.Generic;

namespace P05_ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var inputParams = input.Split();

                var name = inputParams[0];
                var age = int.Parse(inputParams[1]);
                var town = inputParams[2];

                people.Add(new Person(name, age, town));
            }

            var indexOfPerson = int.Parse(Console.ReadLine()) - 1;
            var personToCompare = people[indexOfPerson];
            var matches = 0;

            foreach (var person in people)
            {
                var value = person.CompareTo(personToCompare);

                if (value == 0)
                {
                    matches++;
                }
            }

            var result = matches < 2 ? "No matches" : $"{matches} {people.Count - matches} {people.Count}";
            Console.WriteLine(result);
        }
    }
}
