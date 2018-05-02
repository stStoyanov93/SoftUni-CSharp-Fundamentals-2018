using System;

namespace P02_KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = x => Console.WriteLine($"Sir {x}");

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
