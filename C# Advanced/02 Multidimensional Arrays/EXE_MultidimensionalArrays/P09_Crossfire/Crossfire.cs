using System;
using System.Collections.Generic;
using System.Linq;

namespace P09_Crossfire
{
    class Crossfire
    {
        static void Main(string[] args)
        {
            var nestedList = InitialiseCollection();
            BombCollection(nestedList);           

            for (int row = 0; row < nestedList.Count; row++)
            {
                Console.WriteLine(string.Join(" ", nestedList[row]));
            }
        }

        private static List<List<int>> InitialiseCollection()
        {
            var dimentions = Console.ReadLine()
               .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var rows = dimentions[0];
            var cols = dimentions[1];

            var nestedList = new List<List<int>>();

            var counter = 0;

            for (int row = 0; row < rows; row++)
            {
                var innerList = new List<int>();

                for (int col = 0; col < cols; col++)
                {
                    counter++;
                    innerList.Add(counter);
                }

                nestedList.Add(innerList);
            }

            return nestedList;
        }

        private static void BombCollection(List<List<int>> nestedList)
        {
            string input;

            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var inputParams = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var rowToHit = inputParams[0];
                var colToHit = inputParams[1];
                var radiusImpact = inputParams[2];

                for (int row = 0; row < nestedList.Count; row++)
                {
                    for (int col = 0; col < nestedList[row].Count; col++)
                    {
                        if ((row == rowToHit && Math.Abs(col - colToHit) <= radiusImpact)
                            || (col == colToHit && Math.Abs(row - rowToHit) <= radiusImpact))
                        {
                            nestedList[row][col] = 0;
                        }
                    }
                }

                RemoveEmptyCells(nestedList);
            }
        }

        private static void RemoveEmptyCells(List<List<int>> nestedList)
        {
            for (int row = 0; row < nestedList.Count; row++)
            {
                nestedList[row].RemoveAll(x => x == 0);

                if (nestedList[row].Count == 0)
                {
                    nestedList.RemoveAt(row);
                    row--;
                }
            }
        }
    }
}
