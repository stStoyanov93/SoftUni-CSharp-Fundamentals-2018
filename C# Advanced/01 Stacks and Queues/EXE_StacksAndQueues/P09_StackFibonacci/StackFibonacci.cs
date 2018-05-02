using System;
using System.Collections.Generic;

namespace P09_StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(n));
        }

        private static long GetFibonacci(int n)
        {
            var stack = new Stack<long>(new[] { 0L, 1L });

            for (int i = 0; i < n - 1; i++)
            {
                long numberMinusOne = stack.Pop();
                long numberMinusTwo = stack.Peek();
                stack.Push(numberMinusOne);
                stack.Push(numberMinusOne + numberMinusTwo);
            }

            return stack.Peek();
        }
    }
}
