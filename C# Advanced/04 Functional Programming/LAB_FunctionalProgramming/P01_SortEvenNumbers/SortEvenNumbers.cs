using System;
using System.Linq;

namespace P01_SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            Func<string, int> integerParser = int.Parse;
            Func<int, bool> isEven = n => n % 2 == 0;

            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(integerParser)
                .Where(isEven)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
