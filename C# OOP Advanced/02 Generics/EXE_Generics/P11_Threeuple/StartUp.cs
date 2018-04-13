﻿using System;

namespace P11_Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split();
            tokens[0] = $"{tokens[0]} {tokens[1]}";
            var firstTuple = new Threeuple<string, string, string>(tokens[0], tokens[2], tokens[3]);
            PrintTuple(firstTuple);

            tokens = Console.ReadLine().Split();
            bool isDrunk = tokens[2] == "drunk";
            var secondTuple = new Threeuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), isDrunk);
            PrintTuple(secondTuple);

            tokens = Console.ReadLine().Split();
            var thirdTuple = new Threeuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);
            PrintTuple(thirdTuple);
        }

        private static void PrintTuple<T1, T2, T3>(Threeuple<T1, T2, T3> threeuple)
        {
            Console.WriteLine($"{threeuple.Item1} -> {threeuple.Item2} -> {threeuple.Item3}");
        }
    }
}
