using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var family = new Family();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];
            var age = int.Parse(input[1]);

            family.AddMember(new Person(age, name));
        }

        var oldersMember = family.GetOldestMember();
        Console.WriteLine($"{oldersMember.Name} {oldersMember.Age}");
    }
}

