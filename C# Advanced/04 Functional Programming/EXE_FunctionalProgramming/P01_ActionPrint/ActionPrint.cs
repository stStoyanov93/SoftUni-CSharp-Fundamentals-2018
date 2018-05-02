using System;

namespace P01_ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> print = n => Console.WriteLine(string.Join(Environment.NewLine, names));

            print(names);
        }
    }
}
