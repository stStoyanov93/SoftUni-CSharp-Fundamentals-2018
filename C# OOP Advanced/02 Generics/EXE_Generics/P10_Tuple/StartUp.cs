using System;

namespace P10_Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            tokens[0] = $"{tokens[0]} {tokens[1]}";
            var firstTuple = new Tuple<string, string>(tokens[0], tokens[2]);
            PrintTuple(firstTuple);

            tokens = Console.ReadLine().Split();
            var secondTuple = new Tuple<string, int>(tokens[0], int.Parse(tokens[1]));
            PrintTuple(secondTuple);

            tokens = Console.ReadLine().Split();
            var thirdTuple = new Tuple<int, double>(int.Parse(tokens[0]), double.Parse(tokens[1]));
            PrintTuple(thirdTuple);
        }

        private static void PrintTuple<T1, T2>(Tuple<T1, T2> tuple)
        {
            Console.WriteLine($"{tuple.Item1} -> {tuple.Item2}");
        }
    }
}
