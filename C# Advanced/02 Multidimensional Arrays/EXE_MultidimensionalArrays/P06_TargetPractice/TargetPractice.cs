using System;
using System.Linq;
using System.Text;

namespace P06_TargetPractice
{
    class TargetPractic
    {
        static void Main(string[] args)
        {
            var matrix = CreateMatrix();

            var snake = Console.ReadLine();

            var shotParameters = GetTargetLocation();

            FillMatrix(snake, matrix);

            ShootMatrix(shotParameters, matrix);

            FillEmptyCells(matrix);

            PrintMatrix(matrix);
        }

        private static char[,] CreateMatrix()
        {
            int[] dimensions = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new char[rows, cols];
            return matrix;
        }

        private static int[] GetTargetLocation()
        {
            int[] shotParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            return shotParams;
        }

        private static void FillMatrix(string snake, char[,] matrix)
        {
            var snakeIndex = 0;
            var snakeLength = snake.Length;
            var rowIsEven = true;

            var rowsLength = matrix.GetLength(0);
            var colsLength = matrix.GetLength(1);

            for (int row = rowsLength - 1; row >= 0; row--)
            {
                if (rowIsEven)
                {
                    for (int col = colsLength - 1; col >= 0; col--)
                    {
                        if (snakeIndex == snakeLength)
                        {
                            snakeIndex = 0;
                        }

                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        rowIsEven = false;
                    }
                }
                else
                {
                    for (int col = 0; col < colsLength; col++)
                    {
                        if (snakeIndex == snakeLength)
                        {
                            snakeIndex = 0;
                        }

                        matrix[row, col] = snake[snakeIndex];
                        snakeIndex++;
                        rowIsEven = true;
                    }
                }
            }
        }

        private static void ShootMatrix(int[] shotParameters, char[,] matrix)
        {
            var rowsLength = matrix.GetLength(0);
            var colsLength = matrix.GetLength(1);

            int impactRow = shotParameters[0];
            int impactCol = shotParameters[1];
            int radius = shotParameters[2];

            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < colsLength; col++)
                {
                    int a = impactRow - row;
                    int b = impactCol - col;
                    double distance = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                    if (distance <= radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void FillEmptyCells(char[,] matrix)
        {
            var rowsLength = matrix.GetLength(0);
            var colsLength = matrix.GetLength(1);

            for (int col = 0; col < colsLength; col++)
            {
                int emptyCells = 0;

                for (int row = rowsLength - 1; row >= 0; row--)
                {
                    if (matrix[row, col] == ' ')
                    {
                        emptyCells++;
                    }
                    else if (emptyCells > 0)
                    {
                        matrix[row + emptyCells, col] = matrix[row, col];
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            var rowsLength = matrix.GetLength(0);
            var colsLength = matrix.GetLength(1);

            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < rowsLength; row++)
            {
                for (int col = 0; col < colsLength; col++)
                {
                    sb.Append(matrix[row, col]);
                }

                sb.AppendLine();
            }

            string result = sb.ToString().TrimEnd();
            Console.WriteLine(result);
        }
    }
}