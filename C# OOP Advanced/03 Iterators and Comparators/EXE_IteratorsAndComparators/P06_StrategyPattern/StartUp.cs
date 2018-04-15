using System;
using System.Collections.Generic;

namespace P06_StrategyPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sortedPeopleByName = new SortedSet<Person>(new PersonNameComperator());
            var sortedPeopleByAge = new SortedSet<Person>(new PersonAgeComperator());

            var countOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPeople; i++)
            {
                var inputParams = Console.ReadLine().Split();

                var name = inputParams[0];
                var age = int.Parse(inputParams[1]);

                var person = new Person(name, age);
                sortedPeopleByName.Add(person);
                sortedPeopleByAge.Add(person);
            }

            foreach (var person in sortedPeopleByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedPeopleByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
