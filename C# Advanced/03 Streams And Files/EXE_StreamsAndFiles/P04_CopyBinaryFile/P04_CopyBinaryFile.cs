using System.IO;

namespace P04_CopyBinaryFile
{
    public class P04_CopyBinaryFile
    {
        public static void Main()
        {

            var sourceFilePath = @"..\Resources\copyMe.png";
            var copyFilePath = @"..\Resources\CopiedImage.png";

            using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var copyFile = new FileStream(copyFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = sourceFile.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        copyFile.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
