using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_BasicQueueOperations
{
    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var inputControl = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var numbersToAdd = Math.Min(inputControl[0], inputNumbers.Length);

            var queue = new Queue<int>();

            for (int i = 0; i < numbersToAdd; i++)
            {
                queue.Enqueue(inputNumbers[i]);
            }

            var numbersToPop = Math.Min(inputControl[1], queue.Count);
            var itemToFind = inputControl[2];

            for (int i = 0; i < numbersToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(itemToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
