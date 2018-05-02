using System;
using System.Collections.Generic;
using System.Linq;

namespace P08_CustomComparator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            CustomComparator customComparator = new CustomComparator();

            Array.Sort(numbers, customComparator);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
