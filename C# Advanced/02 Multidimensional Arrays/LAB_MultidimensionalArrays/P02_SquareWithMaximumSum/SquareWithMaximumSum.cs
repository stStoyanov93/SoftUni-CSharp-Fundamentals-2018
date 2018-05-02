using System;
using System.Linq;

namespace P02_SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var arrRows = input[0];
            var arrColumns = input[1];

            var matrix = new int[arrRows, arrColumns];

            for (int row = 0; row < arrRows; row++)
            {
                var numbers = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int column = 0; column < arrColumns; column++)
                {
                    matrix[row, column] = numbers[column];
                }
            }

            var sum = 0;
            var rowIndex = 0;
            var columnIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int columns = 0; columns < matrix.GetLength(1) - 1; columns++)
                {
                    var tempSum = matrix[rows, columns] + matrix[rows, columns + 1]
                        + matrix[rows + 1, columns] + matrix[rows + 1, columns + 1];

                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = rows;
                        columnIndex = columns;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowIndex, columnIndex]} {matrix[rowIndex, columnIndex + 1]}");
            Console.WriteLine($"{matrix[rowIndex + 1, columnIndex]} {matrix[rowIndex + 1, columnIndex + 1]}");
            Console.WriteLine(sum);
        }
    }
}
