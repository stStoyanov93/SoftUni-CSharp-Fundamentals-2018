using System;
using System.Linq;

namespace P07_LegoBlocks
{
    class LegoBlocks
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var firstMatrix = CreateMatrix(rows);
            var secondMatrix = CreateMatrix(rows);

            var blocksCount = GetBlocksCount(firstMatrix, secondMatrix);

            if (blocksCount > 0)
            {
                Console.WriteLine($"The total number of cells is: {blocksCount}");
            }
            else
            {
                PrintMatrix(firstMatrix, secondMatrix);
            }
        }       

        private static long GetBlocksCount(int[][] matrixA, int[][] matrixB)
        {
            long firstRowCount = matrixA[0].Length + matrixB[0].Length;
            long totalCount = firstRowCount;
            var isValidBlock = true;

            for (int row = 1; row < matrixA.Length; row++)
            {
                var currentRowCount = matrixA[row].Length + matrixB[row].Length;
                totalCount += currentRowCount;

                if (currentRowCount != firstRowCount)
                {
                    isValidBlock = false;
                }
            }

            if (isValidBlock)
            {
                return 0;
            }

            return totalCount;
        }

        private static int[][] CreateMatrix(int rows)
        {
            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Trim()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }

        private static void PrintMatrix(int[][] firstMatrix, int[][] secondMatrix)
        {
            var rows = firstMatrix.Length;

            var joinedMatrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                joinedMatrix[row] = firstMatrix[row].Concat(secondMatrix[row].Reverse()).ToArray();
            }

            foreach (var row in joinedMatrix)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }
        }
    }
}