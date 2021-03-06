﻿using System;
using System.Linq;

namespace P04_Froggy
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var stones = Console.ReadLine()
            .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
