using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace P06_ZippingSlicedFiles
{
    public class P06_ZippingSlicedFiles
    {
        private static List<string> fileParts = new List<string>();

        public static void Main()
        {

            int partsCount = int.Parse(Console.ReadLine());

            ZipIntoParts(partsCount);         
        }

        private static void ZipIntoParts(int partsCount)
        {
            var buffer = new byte[4096];

            using (var sourceFile = new FileStream(@"..\Resources\sliceMe.mp4", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);

                for (int index = 0; index < partsCount; index++)
                {
                    var filePartName = $"Part-{index}.mp4";

                    fileParts.Add(filePartName);

                    using (var destinationFile = new GZipStream(new FileStream($@"..\Resources\{filePartName}.gz", FileMode.Create), CompressionLevel.Optimal))
                    {
                        int totalBytes = 0;

                        while (totalBytes < partSize)
                        {
                            int readBytes = sourceFile.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            destinationFile.Write(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }
    }
}
