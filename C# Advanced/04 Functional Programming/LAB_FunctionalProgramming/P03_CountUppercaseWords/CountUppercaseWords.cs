using System;
using System.Linq;

namespace P03_CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {           
            Func<string, bool> isFirstLetterCapital = s => char.IsUpper(s[0]);

            var input = Console.ReadLine();

            var words = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(isFirstLetterCapital)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
