using System;
using System.Linq;

namespace P03_SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimentions[0];
            var cols = dimentions[1];

            var matrix = new string[rows, cols];
            FillMatrix(matrix, rows, cols);
            var count = FindNumberOfSquares(matrix, rows, cols);
            Console.WriteLine(count);

        }

        private static int FindNumberOfSquares(string[,] matrix, int rows, int cols)
        {
            var count = 0;
            var rowLength = rows - 1;
            var colLength = cols - 1;

            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    var SquareIsIdentical = matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1];

                    if (SquareIsIdentical)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static void FillMatrix(string[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int column = 0; column < cols; column++)
                {
                    matrix[row, column] = input[column];
                }
            }
        }
    }
}
