using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);

            if (age > 30)
            {
                people.Add(new Person(age, name));
            }
        }

        var sortedPeopleByName = people.OrderBy(x => x.Name);

        foreach (var item in sortedPeopleByName)
        {
            Console.WriteLine($"{item.Name} - {item.Age}");
        }
    }
}

