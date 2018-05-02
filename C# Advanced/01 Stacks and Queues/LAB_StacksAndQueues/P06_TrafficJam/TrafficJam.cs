using System;
using System.Collections.Generic;

namespace P06_TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            var allowedCars = int.Parse(Console.ReadLine());
            int totalCars = 0;
            var queue = new Queue<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine($"{totalCars} cars passed the crossroads.");
                    break;
                }
                else if (input == "green")
                {
                    var carsToPass = Math.Min(queue.Count, allowedCars);

                    for (int i = 0; i < carsToPass; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        totalCars++;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
        }
    }
}
