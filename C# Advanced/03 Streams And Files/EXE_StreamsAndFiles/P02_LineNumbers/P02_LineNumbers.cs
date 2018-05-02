using System;
using System.IO;

namespace P02_LineNumbers
{
    class P02_LineNumbers
    {
        static void Main(string[] args)
        {
            var lineNumber = 1;

            using (var reader = new StreamReader(@"..\Resources\text.txt"))
            {
                using (var writer = new StreamWriter(@"..\Resources\textWithLines.txt"))
                {
                    while (true)
                    {
                        var line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"Line {lineNumber}: {line}");

                        lineNumber++;
                    }
                }            
            }
        }
    }
}
