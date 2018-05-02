using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            var pumpsCount = int.Parse(Console.ReadLine());
            var pumpsQueue = new Queue<int[]>();

            for (int i = 0; i < pumpsCount; i++)
            {
                var pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pumpsQueue.Enqueue(pump);
            }

            for (int currentStart = 0; currentStart < pumpsCount - 1; currentStart++)
            {
                var fuel = 0;
                var hasEnoughFuel = true;

                for (int pumpsPassed = 0; pumpsPassed < pumpsCount; pumpsPassed++)
                {
                    var currentPump = pumpsQueue.Dequeue();
                    var pumpFuel = currentPump[0];
                    var distance = currentPump[1];

                    pumpsQueue.Enqueue(currentPump);

                    fuel += pumpFuel - distance;

                    if (fuel < 0)
                    {
                        currentStart += pumpsPassed;
                        hasEnoughFuel = false;
                        break;
                    }
                }

                if (hasEnoughFuel)
                {
                    Console.WriteLine(currentStart);
                    break;
                }
            }
        }
    }
}
