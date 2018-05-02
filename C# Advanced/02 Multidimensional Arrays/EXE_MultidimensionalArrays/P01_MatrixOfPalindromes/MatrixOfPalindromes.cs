using System;
using System.Linq;

namespace P01_MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimentions[0];
            var columns = dimentions[1];

            var matrix = new string[rows, columns];
            FillMatrix(matrix, rows, columns);
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write(matrix[i, y] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(string[,] matrix, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                var startChar = 'a' + i;

                for (int y = 0; y < columns; y++)
                {
                    var firstChar = (char)startChar;
                    var secondChar = (char)(startChar + y);

                    matrix[i, y] = $"{firstChar}{secondChar}{firstChar}";
                }
            }
        }
    }
}
