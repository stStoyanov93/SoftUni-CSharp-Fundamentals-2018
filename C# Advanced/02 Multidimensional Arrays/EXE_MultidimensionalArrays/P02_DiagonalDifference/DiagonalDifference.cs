using System;
using System.Linq;

namespace P02_DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            var dimention = int.Parse(Console.ReadLine());
            var matrix = new long[dimention, dimention];
            FillMatrix(matrix, dimention);
            var absoluteDifference = CalculateDifference(matrix, dimention);
            Console.WriteLine(absoluteDifference);
        }

        private static void FillMatrix(long[,] matrix, int dimention)
        {
            for (int row = 0; row < dimention; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                for (int column = 0; column < dimention; column++)
                {
                    matrix[row, column] = input[column];
                }
            }
        }
        private static long CalculateDifference(long[,] matrix, int dimention)
        {
            var primaryDiagonalSum = 0L;
            var secondaryDiagonalSum = 0L;
            var column = 0;
            var lastColumn = dimention - 1L;

            for (int row = 0; row < dimention; row++)
            {
                primaryDiagonalSum += matrix[row, column];
                secondaryDiagonalSum += matrix[row, lastColumn];
                column++;
                lastColumn--;
            }

            return Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
        }
    }
}
