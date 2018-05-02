using System;
using System.Collections.Generic;

namespace P05_FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            Func<string, int> integerParser = n => int.Parse(n);
            var numberOfPeople = int.Parse(Console.ReadLine());

            var people = new Dictionary<string, int>(numberOfPeople);

            for (int i = 0; i < numberOfPeople; i++)
            {
                var input = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                var personName = input[0];
                var personAge = integerParser(input[1]);

                if (!people.ContainsKey(personName))
                {
                    people.Add(personName, personAge);
                }
                else
                {
                    people[personName] = personAge;
                }
            }

            var condition = Console.ReadLine();
            var age = integerParser(Console.ReadLine());
            var nameAgeToFilter = Console.ReadLine();

            var filter = FilterByCondition(condition, age);
            var printer = CreatePrinter(nameAgeToFilter);

            foreach (KeyValuePair<string, int> personNameAgePair in people)
            {
                if (filter(personNameAgePair.Value))
                {
                    printer(personNameAgePair);
                }
            }
        }

        static Func<int, bool> FilterByCondition(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }

            return x => x >= age;
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string inputFormat)
        {
            switch (inputFormat)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                default :
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
            }
        }
    }
}
