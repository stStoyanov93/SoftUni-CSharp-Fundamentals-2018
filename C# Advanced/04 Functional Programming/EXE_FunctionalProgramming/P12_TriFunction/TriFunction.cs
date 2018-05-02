using System;
using System.Linq;

namespace P12_TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            var targetSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, int, bool> getValidName = (personName, sum) => personName.ToCharArray().Sum(x => x) >= sum;

            var name = names.FirstOrDefault(n => getValidName(n, targetSum));
            Console.WriteLine(name);
        }
    }
}
