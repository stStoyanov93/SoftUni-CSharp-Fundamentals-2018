using System;
using System.Linq;

namespace P01_SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var arrRows = input[0];
            var arrColumns = input[1];

            var matrix = new int[arrRows, arrColumns];

            var sum = 0;

            for (int row = 0; row < arrRows; row++)
            {
                var numbers = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int column = 0; column < arrColumns; column++)
                {
                    matrix[row, column] = numbers[column];
                    sum += numbers[column];
                }
            }

            Console.WriteLine(arrRows);
            Console.WriteLine(arrColumns);
            Console.WriteLine(sum);
        }
    }
}
