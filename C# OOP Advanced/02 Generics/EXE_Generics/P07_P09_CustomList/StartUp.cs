using System;

namespace P07_P09_CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = string.Empty;
            var list = new CustomList<string>();

            while (true)
            {
                input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var inputParams = input.Split();
                var command = inputParams[0];

                switch (command)
                {
                    case "Add":
                        list.Add(inputParams[1]);
                        break;
                    case "Remove":
                        var index = int.Parse(inputParams[1]);
                        var removedElement = list.Remove(index);
                        break;
                    case "Contains":
                        var isContained = list.Contains(inputParams[1]);
                        Console.WriteLine(isContained);
                        break;
                    case "Swap":
                        var firstIndex = int.Parse(inputParams[1]);
                        var secondIndex = int.Parse(inputParams[2]);
                        list.Swap(firstIndex, secondIndex);
                        break;
                    case "Greater":
                        var count = list.CountGreaterThan(inputParams[1]);
                        Console.WriteLine(count);
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Print":
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine(list[i]);
                        }
                        break;
                    case "Sort":
                        list.Sort();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
