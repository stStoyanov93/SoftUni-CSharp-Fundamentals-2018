using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Func<double, double> addVAT = n => n += n * 0.2;

            var prices = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVAT)
                .ToList();

            foreach (var item in prices)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
