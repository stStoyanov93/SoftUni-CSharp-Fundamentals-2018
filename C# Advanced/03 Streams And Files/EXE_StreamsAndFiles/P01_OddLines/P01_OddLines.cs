using System;
using System.IO;

namespace P01_OddLines
{
    class P01_OddLines
    {
        static void Main(string[] args)
        {
            var lineNumber = 0;

            using (var reader = new StreamReader(@"..\Resources\text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }

                    lineNumber++;
                }
            }
        }
    }
}
