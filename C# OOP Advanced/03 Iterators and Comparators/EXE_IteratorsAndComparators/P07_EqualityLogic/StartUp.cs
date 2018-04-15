using System;
using System.Collections.Generic;

namespace P07__EqualityLogic
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var hashedPeople = new HashSet<Person>();
            var sortedPeople = new SortedSet<Person>();

            var countOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPeople; i++)
            {
                var inputParams = Console.ReadLine().Split();

                var name = inputParams[0];
                var age = int.Parse(inputParams[1]);

                var person = new Person(name, age);
                sortedPeople.Add(person);
                hashedPeople.Add(person);
            }

            Console.WriteLine(hashedPeople.Count);
            Console.WriteLine(sortedPeople.Count);
        }
    }
}
