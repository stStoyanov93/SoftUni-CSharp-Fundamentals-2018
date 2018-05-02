using System;
using System.Linq;

namespace P05_RubiksMatrix
{
    class RubiksMatrix
    {
        private static int[,] matrix;

        static void Main(string[] args)
        {
            var cellsOfRowsAndCols = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            matrix = new int[cellsOfRowsAndCols[0], cellsOfRowsAndCols[1]];

            FillMatrix(matrix);
            InterpretCommands(matrix);
            SwapMatrix(matrix);
        }

        private static void FillMatrix(int[,] matrix)
        {
            var count = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }
        }

        private static void InterpretCommands(int[,] matrix)
        {
            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] inputArgs = Console.ReadLine().Split(' ');
                int steps = int.Parse(inputArgs[0]);
                string direction = inputArgs[1];
                int moves = int.Parse(inputArgs[2]);

                switch (direction)
                {
                    case "up":
                        for (int j = 0; j < moves % matrix.GetLength(0); j++)
                        {
                            MoveUp(matrix, steps);
                        }

                        break;

                    case "down":
                        for (int j = 0; j < moves % matrix.GetLength(0); j++)
                        {
                            MoveDown(matrix, steps);
                        }

                        break;

                    case "left":
                        for (int j = 0; j < moves % matrix.GetLength(1); j++)
                        {
                            MoveLeft(matrix, steps);
                        }

                        break;

                    case "right":
                        for (int j = 0; j < moves % matrix.GetLength(1); j++)
                        {
                            MoveRight(matrix, steps);
                        }

                        break;
                }
            }
        }

        private static void MoveRight(int[,] matrix, int row)
        {
            int temp = matrix[row, matrix.GetLength(1) - 1];

            for (int col = matrix.GetLength(1) - 1; col > 0; col--)
            {
                matrix[row, col] = matrix[row, col - 1];
            }

            matrix[row, 0] = temp;
        }

        private static void MoveLeft(int[,] matrix, int row)
        {
            int temp = matrix[row, 0];

            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                matrix[row, col] = matrix[row, col + 1];
            }

            matrix[row, matrix.GetLength(1) - 1] = temp;
        }

        private static void MoveUp(int[,] matrix, int col)
        {
            int temp = matrix[0, col];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                matrix[row, col] = matrix[row + 1, col];
            }

            matrix[matrix.GetLength(0) - 1, col] = temp;
        }

        private static void MoveDown(int[,] matrix, int col)
        {
            int temp = matrix[matrix.GetLength(0) - 1, col];

            for (int row = matrix.GetLength(0) - 1; row > 0; row--)
            {
                matrix[row, col] = matrix[row - 1, col];
            }

            matrix[0, col] = temp;
        }

        private static void SwapMatrix(int[,] matrix)
        {
            int count = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == count)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        int[] swapIndex = FindCellIndex(matrix, count);
                        Console.WriteLine($"Swap ({row}, {col}) with ({swapIndex[0]}, {swapIndex[1]})");
                        int temp = matrix[row, col];
                        matrix[row, col] = matrix[swapIndex[0], swapIndex[1]];
                        matrix[swapIndex[0], swapIndex[1]] = temp;
                    }

                    count++;
                }
            }
        }

        private static int[] FindCellIndex(int[,] matrix, int target)
        {
            int[] cellLocation = new int[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (target == matrix[row, col])
                    {
                        cellLocation[0] = row;
                        cellLocation[1] = col;
                        break;
                    }
                }
            }

            return cellLocation;
        }

    }
}
