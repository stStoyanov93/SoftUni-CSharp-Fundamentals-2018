using System;
using System.Collections.Generic;

namespace P01_ReverseStrings
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var stack = new Stack<char>(input);

            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
