using System;
using System.Linq;

namespace P08_RadioactiveBunnies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var matrix = CreateMatrix();        
            PopulateMatrix(matrix);
            var playerLocation = FindPlayer(matrix);
            var playerStatus = InterpretCommands(matrix, playerLocation);
            PrintMatrix(matrix);
            PrintResult(playerStatus, playerLocation[0], playerLocation[1]);
        }

        private static char[,] CreateMatrix()
        {
            var dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var matrix = new char[dimentions[0], dimentions[1]];

            return matrix;
        }

        private static void PopulateMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputString = Console.ReadLine();

                for (int col = 0; col < inputString.Length; col++)
                {
                    matrix[row, col] = inputString[col];                   
                }
            }
        }

        private static int[] FindPlayer(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        return new int[2] { row, col };
                    }
                }
            }

            throw new InvalidOperationException("Could not find player!");
        }

        private static Status InterpretCommands(char[,] matrix, int[] playerLocation)
        {
            var directions = Console.ReadLine();
            var playerStatus = Status.alive;

            foreach (var direction in directions)
            {
                MovePlayer(matrix, playerLocation, direction, ref playerStatus);
                MultiplyBunnies(matrix, ref playerStatus);

                if (playerStatus != Status.alive)
                {
                    return playerStatus;
                }
            }

            return playerStatus;
        }

        private static void MovePlayer(char[,] matrix, int[] playerLocation, char direction, ref Status playerStatus)
        {
            var nextPosition = new int[] { playerLocation[0], playerLocation[1] };

            switch (direction)
            {
                case 'L':
                    nextPosition[1] = playerLocation[1] - 1;
                    break;
                case 'R':
                    nextPosition[1] = playerLocation[1] + 1;
                    break;
                case 'U':
                    nextPosition[0] = playerLocation[0] - 1;
                    break;
                case 'D':
                    nextPosition[0] = playerLocation[0] + 1;
                    break;
            }

            if (!IsInsideMatrix(matrix, nextPosition[0], nextPosition[1]))
            {
                playerStatus = Status.won;
                matrix[playerLocation[0], playerLocation[1]] = '.';
            }

            else if (matrix[nextPosition[0], nextPosition[1]] == '.')
            {
                matrix[nextPosition[0], nextPosition[1]] = 'P';
                matrix[playerLocation[0], playerLocation[1]] = '.';
                playerLocation[0] = nextPosition[0];
                playerLocation[1] = nextPosition[1];
            }

            else if (matrix[nextPosition[0], nextPosition[1]] == 'B')
            {
                playerStatus = Status.dead;
                matrix[playerLocation[0], playerLocation[1]] = '.';
                playerLocation[0] = nextPosition[0];
                playerLocation[1] = nextPosition[1];
            }
        }

        private static void MultiplyBunnies(char[,] matrix, ref Status playerStatus)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 'B')
                    {
                        continue;
                    }

                    AddSmallBunny(matrix, row - 1, col, ref playerStatus);
                    AddSmallBunny(matrix, row + 1, col, ref playerStatus);
                    AddSmallBunny(matrix, row, col - 1, ref playerStatus);
                    AddSmallBunny(matrix, row, col + 1, ref playerStatus);
                }
            }

            ReplaceSmallBunnies(matrix);
        }

        private static void AddSmallBunny(char[,] matrix, int row, int col, ref Status playerStatus)
        {
            if (IsInsideMatrix(matrix, row, col))
            {

                if (matrix[row, col] == 'P')
                {
                    playerStatus = Status.dead;
                }

                if (matrix[row, col] != 'B')
                {
                    matrix[row, col] = 'b';
                }
            }
        }

        private static void ReplaceSmallBunnies(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'b')
                    {
                        matrix[row, col] = 'B';
                    }
                }
            }
        }

        private static bool IsInsideMatrix(char[,] matrix, int rowPosition, int colPosition)
        {
            var isInside = rowPosition >= 0
                && rowPosition < matrix.GetLength(0)
                && colPosition >= 0 
                && colPosition < matrix.GetLength(1);

            return isInside;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void PrintResult(Status playerStatus, int playerLocationRow, int playerLocationCol)
        {
            Console.WriteLine($"{playerStatus}: {playerLocationRow} {playerLocationCol}");
        } 
    }
}
