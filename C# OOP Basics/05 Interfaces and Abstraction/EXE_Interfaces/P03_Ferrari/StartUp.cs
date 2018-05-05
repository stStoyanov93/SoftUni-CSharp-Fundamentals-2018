using System;

namespace P03_Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            ICar car = new Ferrari(name);

            Console.WriteLine(car);
        }
    }
}
