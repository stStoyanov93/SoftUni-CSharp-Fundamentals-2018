using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03_WordCount
{
    public class P03_WordCount
    {
        public static void Main()
        {
            var words = new Dictionary<string, int>();

            using (var reader = new StreamReader(@"..\Resources\words.txt"))
            {
                while (true)
                {
                    var word = reader.ReadLine();

                    if (word == null)
                    {
                        break;
                    }

                    word = word.ToLower();

                    if (!words.ContainsKey(word))
                    {
                        words[word] = 0;
                    }
                }
            }

            using (var reader = new StreamReader(@"..\Resources\text.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    var currentWords = line
                        .Split(" .,?!:;-[]{}()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .ToArray();

                    foreach (var word in currentWords)
                    {
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(@"..\Resources\result.txt"))
            {
                var result = words
                    .OrderByDescending(w => w.Value)
                    .Select(w => $"{w.Key} - {w.Value}");

                foreach (var w in result)
                {
                    writer.WriteLine(w);
                }
            }
        }
    }
}
