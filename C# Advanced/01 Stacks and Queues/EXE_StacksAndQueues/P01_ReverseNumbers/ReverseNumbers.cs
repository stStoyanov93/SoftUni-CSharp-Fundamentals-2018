using System;
using System.Collections.Generic;

namespace P01_ReverseNumbers
{
    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var stack = new Stack<string>(input);

            Console.WriteLine(String.Join(" ", stack));
        }
    }
}
