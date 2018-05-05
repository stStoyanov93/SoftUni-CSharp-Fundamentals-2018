using System;
using System.Linq;

namespace P03_JediGalaxy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var matrixSize = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var row = matrixSize[0];
            var col = matrixSize[1];

            var matrix = new int[row, col];
            FillMatrix(matrix);

            string command;
            long sum = 0;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                var ivoCoordinates = GetIvosCoordinates(command);
                var ivoRow = ivoCoordinates[0];
                var ivoCol = ivoCoordinates[1];

                var evilPowerCoordinates = GetEvilPowerCoordinates();
                var evilPowerRow = evilPowerCoordinates[0];
                var evilPowerCol = evilPowerCoordinates[1];

                DestroyStars(matrix, evilPowerRow, evilPowerCol);
                
                sum += CalculateIvoPoints(matrix, ivoRow, ivoCol);

            }

            Console.WriteLine(sum);
        }

        private static void FillMatrix(int[,] matrix)
        {
            var value = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        private static int[] GetIvosCoordinates(string command)
        {
            return command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        }

        private static int[] GetEvilPowerCoordinates()
        {
            return Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
        }

        private static void DestroyStars(int[,] matrix, int evilPowerRow, int evilPowerCol)
        {
            while (evilPowerRow >= 0 && evilPowerCol >= 0)
            {
                if (evilPowerRow >= 0 
                    && evilPowerRow < matrix.GetLength(0)
                    && evilPowerCol >= 0 
                    && evilPowerCol < matrix.GetLength(1)
                    )
                {
                    matrix[evilPowerRow, evilPowerCol] = 0;
                }

                evilPowerRow--;
                evilPowerCol--;
            }
        }

        private static long CalculateIvoPoints(int[,] matrix, int ivoRow, int ivoCol)
        {
            long sum = 0;

            while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
            {
                if (ivoRow >= 0 
                    && ivoRow < matrix.GetLength(0)
                    && ivoCol >= 0
                    && ivoCol < matrix.GetLength(1))
                {
                    sum += matrix[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return sum;
        }
    }
}
