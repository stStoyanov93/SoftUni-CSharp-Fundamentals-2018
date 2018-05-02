using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P12_StringMatrixRotation
{
    class StringMatrixRotation
    {
        static void Main(string[] args)
        {
            var degrees = GetRotationDegrees();
            var matrix = CreateMatrix();

            switch (degrees)
            {
                case 0:
                    PrintMatrix(matrix);
                    break;
                case 90:
                    PrintMatrixRotatedBy90(matrix);
                    break;
                case 180:
                    PrintMatrixRotatedBy180(matrix);
                    break;
                case 270:
                    PrintMatrixRotatedBy270(matrix);
                    break;
            }
        }

        private static int GetRotationDegrees()
        {
            var input = Console.ReadLine().Split(new string[] { "Rotate(", ")" }, StringSplitOptions.RemoveEmptyEntries);
            var degrees = int.Parse(input[0]);

            degrees %= 360;

            while (degrees < 0)
            {
                degrees += 360;
            }

            return degrees;
        }

        private static char[][] CreateMatrix()
        {
            var words = new List<string>();

            while (true)
            {
                string text = Console.ReadLine();

                if (text == "END")
                {
                    break;
                }

                words.Add(text);
            }

            var rows = words.Count();
            var cols = words.Select(x => x.Count()).Max();
            var matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var builder = new StringBuilder(words[row]);
                builder.Append(new string(' ', cols - words[row].Length));
                matrix[row] = builder.ToString().ToCharArray();
            }

            return matrix;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void PrintMatrixRotatedBy90(char[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void PrintMatrixRotatedBy180(char[][] matrix)
        {
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                Console.WriteLine(string.Join("", matrix[row].Reverse()));
            }
        }

        private static void PrintMatrixRotatedBy270(char[][] matrix)
        {
            for (int col = matrix[0].Length - 1; col >= 0; col--)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }         
    }
}
