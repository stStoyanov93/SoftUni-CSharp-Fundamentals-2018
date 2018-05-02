using System;
using System.Linq;

namespace P02_SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            Func<string, int> integerParser = int.Parse;

            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(integerParser)
                .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }  
    }
}
