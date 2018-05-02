using System;
using System.Linq;

namespace P06_ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                   .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();

            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> isResultOdd = x => x % divisor != 0;

            numbers = numbers
                .Where(isResultOdd)
                .Reverse()
                .ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
