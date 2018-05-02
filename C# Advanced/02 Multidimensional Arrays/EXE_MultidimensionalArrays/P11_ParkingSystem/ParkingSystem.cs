using System;
using System.Collections.Generic;
using System.Linq;

namespace P11_ParkingSystem
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            var parking = new Dictionary<int, HashSet<int>>();

            var dimentions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimentions[0];
            var cols = dimentions[1];

            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                var inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var entryRow = int.Parse(inputParams[0]);
                var targetRow = int.Parse(inputParams[1]);
                var targetCol = int.Parse(inputParams[2]);

                var parkColumn = 0;

                if (!IsSpotTaken(parking, targetRow, targetCol))
                {
                    parkColumn = targetCol;
                }
                else
                {
                    for (int i = 1; i < cols - 1; i++)
                    {
                        if (((targetCol - i) > 0) && !IsSpotTaken(parking, targetRow, (targetCol - i)))
                        {
                            parkColumn = (targetCol - i);
                            break;
                        }
                        else if (((targetCol + i) < cols) && !IsSpotTaken(parking, targetRow, (targetCol + i)))
                        {
                            parkColumn = (targetCol + i);
                            break;
                        }
                    }
                }

                if (parkColumn == 0)
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
                else
                {
                    parking[targetRow].Add(parkColumn);
                    var steps = Math.Abs(entryRow - targetRow) + 1 + parkColumn;

                    Console.WriteLine(steps);
                }
            }
        }

        private static bool IsSpotTaken(Dictionary<int, HashSet<int>> parking, int row, int col)
        {
            if (parking.ContainsKey(row))
            {
                if (parking[row].Contains(col))
                {
                    return true;
                }
            }
            else
            {
                parking.Add(row, new HashSet<int>());
            }

            return false;
        }
    }
}
