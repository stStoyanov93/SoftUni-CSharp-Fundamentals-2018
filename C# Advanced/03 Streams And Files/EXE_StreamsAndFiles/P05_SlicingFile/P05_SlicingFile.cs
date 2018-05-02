using System;
using System.Collections.Generic;
using System.IO;

namespace P05_SlicingFile
{
    public class P05_SlicingFile
    {
        private static List<string> fileParts = new List<string>();

        public static void Main()
        {

            int partsCount = int.Parse(Console.ReadLine());

            SliceFileIntoParts(partsCount);

            AssembleFileFromParts();
        }

        private static void AssembleFileFromParts()
        {
            var buffer = new byte[4096];

            using (var assembledVideo = new FileStream(@"..\Resources\assembledVideo.mp4", FileMode.Create))
            {
                for (int indexOfPart = 0; indexOfPart < fileParts.Count; indexOfPart++)
                {
                    using (var reader = new FileStream($@"..\Resources\{fileParts[indexOfPart]}", FileMode.Open))
                    {
                        while (true)
                        {
                            int readBytes = reader.Read(buffer, 0, buffer.Length);

                            if (readBytes == 0)
                            {
                                break;
                            }

                            assembledVideo.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }

        private static void SliceFileIntoParts(int partsCount)
        {
            var buffer = new byte[4096];

            using (var sourceFile = new FileStream(@"..\Resources\sliceMe.mp4", FileMode.Open))
            {
                var partSize = Math.Ceiling((double)sourceFile.Length / partsCount);

                for (int index = 0; index < partsCount; index++)
                {
                    var filePartName = $"Part-{index}.mp4";

                    fileParts.Add(filePartName);

                    using (var destinationFile = new FileStream($@"..\Resources\{filePartName}", FileMode.Create))
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
