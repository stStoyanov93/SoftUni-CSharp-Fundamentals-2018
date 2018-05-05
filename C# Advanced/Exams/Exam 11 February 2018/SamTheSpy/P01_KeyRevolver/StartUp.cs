using System;
using System.Collections.Generic;
using System.Linq;

namespace T01
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunbarrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var money = int.Parse(Console.ReadLine());

            var bulletsUsed = 0;
            var tempBulletsUsed = 0;

            while (bullets.Any() && locks.Any())
            {
                bulletsUsed++;
                tempBulletsUsed++;

                var currentBullet = bullets.Pop();

                if (currentBullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }


                if (tempBulletsUsed == gunbarrelSize && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    tempBulletsUsed = 0;
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var moneyEarned = money - (bulletsUsed * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }

        }
    }
}