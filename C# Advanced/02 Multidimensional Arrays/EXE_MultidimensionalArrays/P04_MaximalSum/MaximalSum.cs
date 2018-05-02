using System;
using System.Linq;

namespace P04_MaximalSum
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimentions[0];
            var cols = dimentions[1];

            var matrix = new int[rows, cols];
            FillMatrix(matrix, rows, cols);
            FindRectangularSum(matrix, rows, cols);

        }

        private static void FindRectangularSum(int[,] matrix, int rows, int cols)
        {
            var sum = int.MinValue;
            var startRowIndex = 0;
            var startColIndex = 0;

            var rowLength = rows - 2;
            var colLength = cols - 2;

            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    var currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int row = 0; row < 3; row++)
            {
                Console.WriteLine($"{matrix[startRowIndex, startColIndex]} {matrix[startRowIndex, startColIndex + 1]} {matrix[startRowIndex, startColIndex + 2]}");
                startRowIndex++;
            }
        }

        private static void FillMatrix(int[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < cols; column++)
                {
                    matrix[row, column] = input[column];
                }
            }
        }
    }
}
