using System;
using System.Linq;

namespace P07_PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Func<string, bool> hasValidLength = x => x.Length <= length;

            string[] names = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            names.Where(x => hasValidLength(x))
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
