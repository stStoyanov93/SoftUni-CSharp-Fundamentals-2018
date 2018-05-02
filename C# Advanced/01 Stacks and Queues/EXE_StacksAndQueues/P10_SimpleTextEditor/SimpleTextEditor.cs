using System;
using System.Collections.Generic;

namespace P10_SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var numberOfOperations = int.Parse(Console.ReadLine());
            var text = string.Empty;
            var oldTextVersions = new Stack<string>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                var commandArguments = Console.ReadLine().Split();
                var command = commandArguments[0];

                switch (command)
                {
                    case "1":
                        oldTextVersions.Push(text);
                        text += commandArguments[1];                       
                        break;
                    case "2":
                        oldTextVersions.Push(text);
                        var charsToErase = int.Parse(commandArguments[1]);
                        text = text.Substring(0, text.Length - charsToErase);
                        break;
                    case "3":
                        var index = int.Parse(commandArguments[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = oldTextVersions.Pop();
                        break;
                }
            }
        }
    }
}