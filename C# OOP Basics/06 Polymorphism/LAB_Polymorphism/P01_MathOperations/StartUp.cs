using System;

namespace P01_MathOperations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var mathOps = new MathOperations();

            Console.WriteLine(mathOps.Add(2.5, 2.5, 2.1));
            Console.WriteLine(mathOps.Add(5.5m, 6.5m, 3.4m));
            Console.WriteLine(mathOps.Add(3, 5));
        }
    }
}
