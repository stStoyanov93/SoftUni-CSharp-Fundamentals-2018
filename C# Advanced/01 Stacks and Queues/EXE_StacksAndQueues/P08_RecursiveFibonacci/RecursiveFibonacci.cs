using System;

namespace P08_RecursiveFibonacci
{
    class RecursiveFibonacci
    {

        private static long[] fibonacciNumbers;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            fibonacciNumbers = new long[n];

            Console.WriteLine(GetFibonacci(n - 1));
        }

        private static long GetFibonacci(int value)
        {
            if (value < 2)
            {
                return 1;
            }
            else if (fibonacciNumbers[value] == 0)
            {
                fibonacciNumbers[value] = GetFibonacci(value - 1) + GetFibonacci(value - 2);
            }

            return fibonacciNumbers[value];
        }
    }
}
