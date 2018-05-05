using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace T03
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var builder = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                builder.Append(line);
            }

            var input = builder.ToString();
            var pattern = @"\[\D*(\d{3,})\D*\]|{\D*(\d{3,})\D*}";
            var regex = new Regex(pattern);
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var criptoBlockLength = match.Value.Length;

                foreach (var group in match.Groups)
                {
                    var s = group.ToString();

                    if (s.Length > 0 && Char.IsDigit(s[0]))
                    {
                        if (s.Length % 3 != 0)
                        {
                            continue;
                        }

                        for (int i = 0; i < s.Length; i += 3)
                        {
                            int val = int.Parse($"{s[i]}{s[i + 1]}{s[i + 2]}") - criptoBlockLength;
                            var c = Convert.ToChar(val);
                            Console.Write($"{c}");
                        }
                    }
                }
            }
        }
    }
}