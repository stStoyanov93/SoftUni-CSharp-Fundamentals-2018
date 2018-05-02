using System;

namespace P10_TheHeiganDance
{
    class TheHeiganDance
    {
        private const double cloud = 3500.0;
        private const double eruption = 6000.0;

        static void Main(string[] args)
        {
            var matrix = CreateMatrix();

            double playerHealth = 18500;
            double heiganHealth = 3000000;

            var playerPosition = new int[] { 7, 7 };
            var playerDamage = double.Parse(Console.ReadLine());
            var lastMagic = string.Empty;

            while (true)
            {
                if (playerHealth >= 0)
                {
                    heiganHealth -= playerDamage;
                }

                if (lastMagic == "Cloud")
                {
                    playerHealth -= cloud;
                }

                if (playerHealth <= 0 || heiganHealth <= 0)
                {
                    break;
                }

                var inputParams = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
               
                var magicType = inputParams[0];
                var targetRow = int.Parse(inputParams[1]);
                var targetCol = int.Parse(inputParams[2]);

                playerHealth = PlayerTriesToEvadeAttack(playerHealth, magicType,
                    targetRow, targetCol, playerPosition, ref lastMagic);                
            }

            if (lastMagic == "Cloud")
            {
                lastMagic = "Plague Cloud";
            }
            else
            {
                lastMagic = "Eruption";
            }

            PrintResult(playerHealth, heiganHealth, playerPosition, lastMagic);
        }

        private static int[][] CreateMatrix()
        {
            var matrix = new int[15][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = new int[15];
            }

            return matrix;
        }

        private static double PlayerTriesToEvadeAttack(double playerHealth, string magicType, int targetRow, int targetCol, int[] playerPosition, ref string lastMagic)
        {
            var playerRow = playerPosition[0];
            var playerCol = playerPosition[1];

            if (IsPlayerInRange(targetRow, targetCol, playerRow, playerCol))
            {
                if (!IsPlayerInRange(targetRow, targetCol, playerRow - 1, playerCol) && !IsBlocked(playerRow - 1))
                {
                    playerRow--;
                    lastMagic = string.Empty;
                }
                else if (!IsPlayerInRange(targetRow, targetCol, playerRow + 1, playerCol) && !IsBlocked(playerRow + 1))
                {
                    playerRow++;
                    lastMagic = string.Empty;
                }
                else if (!IsPlayerInRange(targetRow, targetCol, playerRow, playerCol - 1) && !IsBlocked(playerCol - 1))
                {
                    playerCol--;
                    lastMagic = string.Empty;
                }
                else if (!IsPlayerInRange(targetRow, targetCol, playerRow, playerCol + 1) && !IsBlocked(playerCol + 1))
                {
                    playerCol++;
                    lastMagic = string.Empty;
                }
                else
                {
                    lastMagic = magicType;

                    if (magicType == "Cloud")
                    {
                        playerHealth -= cloud;
                    }
                    else if (magicType == "Eruption")
                    {
                        playerHealth -= eruption;
                    }
                }
            }

            playerPosition[0] = playerRow;
            playerPosition[1] = playerCol;
            return playerHealth;
        }

        private static bool IsPlayerInRange(int targetRow, int targetCol, int moveRow, int moveCol)
        {
            var isInRange = ((targetRow - 1 <= moveRow && moveRow <= targetRow + 1)
                    && (targetCol - 1 <= moveCol && moveCol <= targetCol + 1));

            return isInRange;
        }

        private static bool IsBlocked(int position)
        {
            return position < 0 || position >= 15;
        }

        private static void PrintResult(double playerHealth, double heiganHealth, int[] playerPosition, string lastMagic)
        {
            var playerRow = playerPosition[0];
            var playerCol = playerPosition[1];

            if (heiganHealth <= 0 && playerHealth > 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: {playerHealth}");
                Console.WriteLine($"Final position: {playerRow}, {playerCol}");
            }
            else if (playerHealth <= 0 && heiganHealth > 0)
            {
                Console.WriteLine($"Heigan: {heiganHealth:F2}");
                Console.WriteLine($"Player: Killed by {lastMagic}");
                Console.WriteLine($"Final position: {playerRow}, {playerCol}");
            }
            else
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: Killed by {lastMagic}");
                Console.WriteLine($"Final position: {playerRow}, {playerCol}");
            }
        }
    }
}
