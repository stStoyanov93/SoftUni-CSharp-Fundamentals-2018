using System;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        var rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var topPoint = new Point(rectangleCoordinates[0], rectangleCoordinates[1]);
        var bottomPoint = new Point(rectangleCoordinates[2], rectangleCoordinates[3]);
        var rectangle = new Rectangle(topPoint, bottomPoint);

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var inputParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var x = inputParams[0];
            var y = inputParams[1];
            var point = new Point(x, y);

            if (rectangle.Contains(point))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}

