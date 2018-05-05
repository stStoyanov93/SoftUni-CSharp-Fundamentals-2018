using System;

namespace P01_02_ClassBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(lenght, width, height);
                double surfaceArea = box.SurfaceArea();
                double lateralSurfaceArea = box.LateralSurfaceArea();
                double volume = box.Volume();

                Console.WriteLine($"Surface Area - {surfaceArea:F2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
                Console.WriteLine($"Volume - {volume:F2}");
            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);
            }           
        }
    }
}
