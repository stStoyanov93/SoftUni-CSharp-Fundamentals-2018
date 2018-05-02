using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_BalancedParenthesis
{
    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }

            var opening = new char[] { '(', '[', '{' };
            var closing = new char[] { ')', ']', '}' };

            var stack = new Stack<char>();

            foreach (var item in input)
            {
                if (opening.Contains(item))
                {
                    stack.Push(item);
                }
                else if (closing.Contains(item))
                {
                    var lastItem = stack.Pop();
                    int openingIndex = Array.IndexOf(opening, lastItem);                   
                    int closingIndex = Array.IndexOf(closing, item);

                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
