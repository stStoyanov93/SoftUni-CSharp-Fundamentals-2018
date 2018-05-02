using System;
using System.Linq;

namespace P03_GroupNumbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var arrZeroRemainder = input.Where(x => Math.Abs(x) % 3 == 0).ToArray();
            var arrOneRemainder = input.Where(x => Math.Abs(x) % 3 == 1).ToArray();
            var arrTwoRemainder = input.Where(x => Math.Abs(x) % 3 == 2).ToArray();

            var jaggedArray = new int[3][];

            jaggedArray[0] = arrZeroRemainder;
            jaggedArray[1] = arrOneRemainder;
            jaggedArray[2] = arrTwoRemainder;

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
