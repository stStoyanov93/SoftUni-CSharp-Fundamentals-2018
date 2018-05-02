using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_BasicStackOperations
{
    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var inputControl = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbersToAdd = Math.Min(inputControl[0], inputNumbers.Length);

            var stack = new Stack<int>();

            for (int i = 0; i < numbersToAdd; i++)
            {
                stack.Push(inputNumbers[i]);
            }

            var numbersToPop = Math.Min(inputControl[1], stack.Count);
            var itemToFind = inputControl[2];

            for (int i = 0; i < numbersToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(itemToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
