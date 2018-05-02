using System;

namespace P04_PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            var firstAndLastElement = 1L;
            var jaggedArr = new long[input][];

            for (int heightLevel = 0; heightLevel < input; heightLevel++)
            {
                jaggedArr[heightLevel] = new long[heightLevel + 1];
                jaggedArr[heightLevel][0] = firstAndLastElement;
                jaggedArr[heightLevel][heightLevel] = firstAndLastElement;

                if (heightLevel >= 2)
                {
                    for (int column = 1; column < heightLevel; column++)
                    {
                        jaggedArr[heightLevel][column] = jaggedArr[heightLevel - 1][column - 1]
                            + jaggedArr[heightLevel - 1][column];
                     }
                }                
            }

            foreach (var arr in jaggedArr)
            {
                Console.WriteLine(String.Join(" ", arr));
            }
        }
    }
}
