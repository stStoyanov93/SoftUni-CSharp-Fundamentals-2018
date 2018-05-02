using System;
using System.Linq;

namespace T02
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var room = new char[size][];

            int samCurrentRow = 0;
            int samCurrentCol = 0;

            FillRoom(size, room, ref samCurrentCol, ref samCurrentRow);          

            var orders = Console.ReadLine().ToCharArray();
            var isSamDead = false;

            for (int i = 0; i < orders.Length; i++)
            {
                MoveEnemies(room, ref samCurrentRow, ref samCurrentCol, ref isSamDead);

                if (isSamDead)
                {
                    room[samCurrentRow][samCurrentCol] = 'X';
                    Console.WriteLine($"Sam died at {samCurrentRow}, {samCurrentCol}");
                    PrintBoard(room);
                    return;
                }

                switch (orders[i])
                {
                    case 'W':
                        break;
                    case 'U':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow - 1][samCurrentCol] = 'S';
                        samCurrentRow -= 1;
                        break;
                    case 'D':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow + 1][samCurrentCol] = 'S';
                        samCurrentRow += 1;
                        break;
                    case 'L':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow][samCurrentCol - 1] = 'S';
                        samCurrentCol -= 1;
                        break;
                    case 'R':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow][samCurrentCol + 1] = 'S';
                        samCurrentCol += 1;
                        break;
                }

                if (room[samCurrentRow].Contains('N'))
                {
                    int nCol = Array.IndexOf(room[samCurrentRow], 'N');
                    room[samCurrentRow][nCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintBoard(room);
                    break;
                }
            }
        }

        private static void FillRoom(int size, char[][] room, ref int samCurrentCol, ref int samCurrentRow)
        {
            for (int i = 0; i < size; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();

                if (room[i].Contains('S'))
                {
                    samCurrentRow = i;
                    samCurrentCol = Array.IndexOf(room[i], 'S');
                }
            }
        }

        public static void MoveEnemies(char[][] room, ref int samCurrentRow, ref int samCurrentCol, ref bool isSamDead)
        {
            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Contains('b'))
                {
                    int index = Array.IndexOf(room[row], 'b');
                    if (index == room[row].Length - 1)
                    {
                        room[row][index] = 'd';
                        if (samCurrentRow == row && samCurrentCol < index)
                        {
                            isSamDead = true;
                        }
                    }
                    else
                    {
                        room[row][index] = '.';
                        room[row][index + 1] = 'b';
                    }
                    if (samCurrentRow == row && samCurrentCol > index)
                    {
                        isSamDead = true;
                    }
                }
                else if (room[row].Contains('d'))
                {
                    int index = Array.IndexOf(room[row], 'd');

                    if (index == 0)
                    {
                        room[row][index] = 'b';
                        if (samCurrentRow == row && samCurrentCol > index)
                        {
                            isSamDead = true;
                        }
                    }
                    else
                    {
                        room[row][index] = '.';
                        room[row][index - 1] = 'd';
                    }

                    if (samCurrentRow == row && samCurrentCol < index)
                    {
                        isSamDead = true;
                    }
                }
            }
        }

        private static void PrintBoard(char[][] arr)
        {
            foreach (var row in arr)
            {
                Console.WriteLine(String.Join("", row));
            }
        }
    }
}