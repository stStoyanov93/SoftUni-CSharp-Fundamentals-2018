using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            var lastNumberInRange = int.Parse(Console.ReadLine());

            var dividersSequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> isDivisible = (x, y) => x % y == 0;

            var result = new List<int>();

            for (int i = 1; i <= lastNumberInRange; i++)
            {
                var checkIfDivisible = true;

                foreach (var divider in dividersSequence)
                {
                    if (!isDivisible(i, divider))
                    {
                        checkIfDivisible = false;
                        break;
                    }
                }

                if (checkIfDivisible)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
