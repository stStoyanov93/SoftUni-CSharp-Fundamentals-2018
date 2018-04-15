using System;

namespace P09_LinkedListTraversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var inputParams = Console.ReadLine().Split();
                var command = inputParams[0];

                switch (command)
                {
                    case "Add":
                        var elementToAdd = int.Parse(inputParams[1]);
                        linkedList.Add(elementToAdd);
                        break;
                    case "Remove":
                        var elementToRemove = int.Parse(inputParams[1]);
                        linkedList.Remove(elementToRemove);
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(" ", linkedList));
        }
    }
}
