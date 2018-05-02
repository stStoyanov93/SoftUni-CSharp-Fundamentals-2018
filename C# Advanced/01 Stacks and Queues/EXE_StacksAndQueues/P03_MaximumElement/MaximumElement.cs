using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_MaximumElement
{
    class MaximumElement
    {
        static void Main(string[] args)
        {
            var controlNumber = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);

            for (int i = 0; i < controlNumber; i++)
            {
                var commandParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var command = commandParams[0];

                if (command == 1)
                {
                    var element = commandParams[1];
                    stack.Push(element);

                    if (element >= maxStack.Peek())
                    {
                        maxStack.Push(element);
                    }
                }
                else if (command == 2)
                {
                    var poppedElement = stack.Pop();

                    if (poppedElement == maxStack.Peek())
                    {
                        maxStack.Pop();
                    }
                }
                else
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}
