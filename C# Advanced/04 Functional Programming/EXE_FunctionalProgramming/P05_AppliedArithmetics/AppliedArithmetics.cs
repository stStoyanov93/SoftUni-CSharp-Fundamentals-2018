using System;
using System.Linq;

namespace P05_AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = x => x.Select(n => n += 1).ToArray();
            Func<int[], int[]> subtract = x => x.Select(n => n -= 1).ToArray();
            Func<int[], int[]> multiply = x => x.Select(n => n *= 2).ToArray();

            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();         

            var command = Console.ReadLine();

            while (!command.Equals("end"))
            {
                if (command == "add")
                {
                    numbers = add(numbers);
                }
                else if (command == "subtract")
                {
                    numbers = subtract(numbers);
                }
                else if (command == "multiply")
                {
                    numbers = multiply(numbers);
                }
                else
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
