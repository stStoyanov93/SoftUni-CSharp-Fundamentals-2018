using System;
using System.Linq;

namespace P03_CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> returnMinNumber = x => x.Min();

            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(returnMinNumber(numbers));
        }
    }
}
