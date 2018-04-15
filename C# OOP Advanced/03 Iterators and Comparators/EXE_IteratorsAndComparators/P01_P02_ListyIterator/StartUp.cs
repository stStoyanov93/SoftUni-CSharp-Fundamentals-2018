using System;
using System.Linq;

namespace P01_P02_ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var createCommand = Console.ReadLine().Split();
            ListyIterator<string> listyIterator;

            if (createCommand.Length > 1)
            {
                var tokens = createCommand.Skip(1).ToList();
                listyIterator = new ListyIterator<string>(tokens);
            }
            else
            {
                listyIterator = new ListyIterator<string>();
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException invalidOperation)
                        {
                            Console.WriteLine(invalidOperation.Message);
                        }

                        break;
                    case "PrintAll":

                        foreach (var item in listyIterator)
                        {
                            Console.Write($"{item} ");
                        }

                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
