using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Reverse();
            var stack = new Stack<string>(input);

            while (stack.Count > 1)
            {
                var leftOperant = int.Parse(stack.Pop());
                var operation = stack.Pop();
                var rightOperant = int.Parse(stack.Pop());

                string n;

                if (operation == "+")
                {
                     n = (leftOperant + rightOperant).ToString();
                }
                else
                {
                     n = (leftOperant - rightOperant).ToString();
                }

                stack.Push(n);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
