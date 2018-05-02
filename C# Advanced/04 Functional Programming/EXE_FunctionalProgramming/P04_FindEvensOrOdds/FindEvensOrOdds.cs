using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            var boundaries = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lowerBound = boundaries[0];
            var upperBound = boundaries[1];

            var numbers = new List<int>();

            for (int i = lowerBound; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            var command = Console.ReadLine();

            Func<int, bool> checkEven = x => x % 2 == 0;
            Func<int, bool> checkOdd = x => x % 2 != 0;

            if (command == "even")
            {
                numbers = numbers.Where(checkEven).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
            else if (command == "odd")
            {
                numbers = numbers.Where(checkOdd).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
