using System;

namespace P03_Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Push":

                        for (int i = 1; i < tokens.Length; i++)
                        {
                            stack.Push(int.Parse(tokens[i]));
                        }

                        break;
                    case "Pop":

                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException invalidOperation)
                        {
                            Console.WriteLine(invalidOperation.Message);
                        }

                        break;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var element in stack)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
}
