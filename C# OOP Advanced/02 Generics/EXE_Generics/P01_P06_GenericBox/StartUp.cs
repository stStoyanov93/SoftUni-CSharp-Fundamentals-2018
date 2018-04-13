using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_P06_GenericBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //GenericBoxofString(); //P01
            //GenericBoxofInt(); //P02

            //GenericSwapMethodString(); //P03
            //GenericSwapMethodInt(); //P04

            //GenericCountMethodStrings(); // P05
            GenericCountMethodDoubles(); //06

        }

        public static void GenericBoxofString()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box);
            }
        }
        public static void GenericBoxofInt()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                Console.WriteLine(box);
            }
        }

        public static void GenericSwapMethodString()
        {
            var list = new List<Box<string>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(new Box<string>(input));
            }

            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap(list, command[0], command[1]);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void GenericSwapMethodInt()
        {
            var list = new List<Box<int>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                list.Add(new Box<int>(input));
            }

            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap(list, command[0], command[1]);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public static void Swap<T>(IList<T> box, int firstIndex, int secondIndex)
        {
            var originValue = box[firstIndex];
            box[firstIndex] = box[secondIndex];
            box[secondIndex] = originValue;
        }

        public static void GenericCountMethodStrings()
        {
            var list = new List<Box<string>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(new Box<string>(input));
            }
                          
            var comparisonValue = new Box<string>(Console.ReadLine());
            Console.WriteLine(CountOfGreaterValues(list, comparisonValue));
        }
        public static void GenericCountMethodDoubles()
        {
            var list = new List<Box<double>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(new Box<double>(input));
            }

            var comparisonValue = new Box<double>(double.Parse(Console.ReadLine()));
            Console.WriteLine(CountOfGreaterValues(list, comparisonValue));
        }
        public static int CountOfGreaterValues<T>(IEnumerable<T> box, T comparisonValue)
            where T : IComparable<T>
        {
            var count = 0;

            foreach (var item in box)
            {
                if (item.CompareTo(comparisonValue) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
