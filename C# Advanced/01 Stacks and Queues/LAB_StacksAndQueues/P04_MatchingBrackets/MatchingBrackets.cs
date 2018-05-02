using System;
using System.Collections.Generic;

namespace P04_MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    var expressionStart = stack.Pop();
                    var length = i - expressionStart + 1;
                    Console.WriteLine(input.Substring(expressionStart, length));
                }
            }
        }
    }
}
