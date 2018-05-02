using System;
using System.Collections.Generic;

namespace P03_DecimalToBinaryConverter
{
    class DecimalToBinaryConverter
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            if (number == 0)
            {
                Console.WriteLine("0");
                return;
            }

            var stack = new Stack<int>();

            while (number > 0)
            {
                var rem = number % 2;
                stack.Push(rem);
                number /= 2;
            }
         
            foreach (var item in stack)
            {
                Console.Write(item);
            }
        }
    }
}
