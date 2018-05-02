using System;
using System.Collections.Generic;

namespace P05_HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            var players = Console.ReadLine().Split();
            var number = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(players);

            while (queue.Count > 1)
            {
                for (int i = 1; i < number; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
