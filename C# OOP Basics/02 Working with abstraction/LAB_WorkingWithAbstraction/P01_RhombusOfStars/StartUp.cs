using System;

namespace P01_RhombusOfStars
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int figureSize = int.Parse(Console.ReadLine());

            for (int starCount = 1; starCount <= figureSize; starCount++)
            {        
                PrintRow(figureSize, starCount);
            }

            for (int starCount = figureSize - 1; starCount >= 1; starCount--)
            {
                PrintRow(figureSize, starCount);
            }
        }

        public static void PrintRow(int figureSize, int countOfStars)
        {
            for (int i = 1; i < figureSize - countOfStars; i++)
            {
                Console.Write(" ");
            }

            for (int col = 1; col < countOfStars; col++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("*");
        }
    }
}
